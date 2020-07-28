import { Component, OnInit } from '@angular/core';
import { Paging } from '../../../models/paging';
import { LocationService } from './../../../services/location.service';
@Component({
  selector: 'app-district',
  templateUrl: './district.component.html',
  styleUrls: ['./district.component.css']
})
export class DistrictComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  districts = [];
  constructor(private locationService: LocationService) { }

  ngOnInit(): void {
    this.loadDistrict();
  }
  loadDistrict(page = null){
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.locationService.listDistrict(this.paging).subscribe(res => {
      this.districts = res.data;
      this.paging = res.paging;
    });
  }
}
