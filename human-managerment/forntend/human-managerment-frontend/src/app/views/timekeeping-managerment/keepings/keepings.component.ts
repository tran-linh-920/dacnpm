import { Component, OnInit } from '@angular/core';
import { Paging } from '../../../models/paging';
import { TimeKeepingService } from '../../../services/time-keeping.service';
import { Timekeeping } from '../../../models/timekeeping';

@Component({
  selector: 'app-keepings',
  templateUrl: './keepings.component.html',
  styleUrls: ['./keepings.component.css']
})
export class KeepingsComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  constructor(private timeKeepingService :TimeKeepingService) { }
  timeKeeping =[] ;
  timeKeepingMorning =[];
  timeKeepingAfternoon =[];
  
  ngOnInit(): void {
    this.loadTimeKeeping();
    this.loadTimeKeepingMorning();
    this.loadTimeKeepingAfternoon();
  }
  loadTimeKeepingMorning(){
    this.timeKeepingService.listTimeKeepingMorning().subscribe(res =>{
        this.timeKeepingMorning = res.data;
        this.paging = res.paging;

        this.loadTimeKeepingAfternoon();
    });
  }
  loadTimeKeepingAfternoon(){
    this.timeKeepingService.listTimeKeepingAfternoon().subscribe(res =>{
        this.timeKeepingAfternoon = res.data;
        this.paging = res.paging;
    });
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
      this.loadTimeKeepingMorning();
      this.loadTimeKeepingAfternoon();
      console.log("Đã tạo bảng");
   //   this.paging = res.paging;
    });
  }
  startUpMorning(timeKeeping : Timekeeping){
    this.timeKeepingService.creatTimeKeepingDetailMorning(timeKeeping).subscribe(res => {
      this.loadTimeKeepingMorning();
      this.loadTimeKeepingAfternoon();
    });
  
  } 
  startUpAfternoon(timeKeeping : Timekeeping){
    this.timeKeepingService.creatTimeKeepingDetailAfternoon(timeKeeping).subscribe(res => {
      this.loadTimeKeepingMorning();
      this.loadTimeKeepingAfternoon();
    });
  } 
  refet(){
    this.timeKeepingService.refetTimeKeeping().subscribe(res=> {
      if(res.data ==null){
        
      }
      this.loadTimeKeepingMorning();
      this.loadTimeKeepingAfternoon();
    });
  }
}