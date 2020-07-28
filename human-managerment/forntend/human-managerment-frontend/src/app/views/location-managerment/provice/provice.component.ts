import { Component, OnInit } from '@angular/core';
import { Paging } from '../../../models/paging';
import { LocationService } from './../../../services/location.service';
import { Province } from '../../../models/province';

@Component({
  selector: 'app-provice',
  templateUrl: './provice.component.html',
  styleUrls: ['./provice.component.css']
})
export class ProviceComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  provinces = [];

  constructor(private locationService: LocationService) { }

  ngOnInit(): void {
    this.loadProvince();
  }
  loadProvince(page = null){
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.locationService.listProvince(this.paging).subscribe(res => {
      this.provinces = res.data;
      this.paging = res.paging;
    });
  }
}
