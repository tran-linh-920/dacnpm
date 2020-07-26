import { Component, OnInit } from '@angular/core';
import { Paging } from '../../../models/paging';
import { LocationService } from './../../../services/location.service';

@Component({
  selector: 'app-ward',
  templateUrl: './ward.component.html',
  styleUrls: ['./ward.component.css']
})
export class WardComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  wards = [];
  constructor(private locationService: LocationService) { }


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
  }
}
