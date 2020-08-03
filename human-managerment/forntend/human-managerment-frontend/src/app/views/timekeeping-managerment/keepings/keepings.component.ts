import { Component, OnInit } from '@angular/core';
import { Paging } from '../../../models/paging';
import { TimeKeepingService } from '../../../services/time-keeping.service';

@Component({
  selector: 'app-keepings',
  templateUrl: './keepings.component.html',
  styleUrls: ['./keepings.component.css']
})
export class KeepingsComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  constructor(private timeKeepingService :TimeKeepingService) { }
  timeKeeping =[] ;
  ngOnInit(): void {
    this.loadTimeKeeping();
  }
  
  loadTimeKeeping(){
  
    this.timeKeepingService.listTimeKeeping().subscribe(res => {
      this.timeKeeping = res.data;
      this.paging = res.paging
      console.log(this.timeKeeping);
   //   this.paging = res.paging;
    });
  }
  creatTimeKeeping(){
  
    this.timeKeepingService.save().subscribe(res => {
      this.loadTimeKeeping();
      console.log("Đã tạo bảng");
   //   this.paging = res.paging;
    });
  }
}
