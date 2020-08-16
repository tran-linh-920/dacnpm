import { Component, OnInit, ViewChild } from '@angular/core';
import { Paging } from '../../../models/paging';
import { LocationService } from './../../../services/location.service';
import { Ward } from '../../../models/ward';
import { District } from '../../../models/district';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-ward',
  templateUrl: './ward.component.html',
  styleUrls: ['./ward.component.css']
})
export class WardComponent implements OnInit {
  @ViewChild('wardModal', { static: false }) wardModal: ModalDirective;

  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  ward: Ward = {id: 0} as Ward;
  wards = [];
  districts = [];
  saveForm: FormGroup;

  constructor(private locationService: LocationService,  private fb: FormBuilder) {
    this.saveForm = this.fb.group({
      ward: [''],
      district: [''],
    });
   }

 
  ngOnInit(): void {
    this.loadWard();
  }
  loadWard(page = null){
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.locationService.listWard(this.paging).subscribe(res => {
      console.log(res);
      this.wards = res.data;
      this.paging = res.paging;
    });
    this.locationService.listDistrict(this.paging).subscribe(res => {
      console.log(res);
      this.districts = res.data;
      //this.paging = res.paging;
    });
  };
  save() {
    this.locationService.addWard(this.ward).subscribe(res => {
      console.log(res);
      this.wardModal.hide();
    });
  }
  openModal() {
    this.wardModal.show();
  }
  hideModal() {
    this.wardModal.hide();
  }
}
