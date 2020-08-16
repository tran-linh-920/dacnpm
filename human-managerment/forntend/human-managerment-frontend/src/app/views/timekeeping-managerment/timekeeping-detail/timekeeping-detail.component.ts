import { Component, OnInit } from '@angular/core';
import { TimeKeepingDetailService } from '../../../services/time-keeping-detail.service';
import { Paging } from '../../../models/paging';
import { TimekeepingDetail } from '../../../models/timekeeping-detail';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-timekeeping-detail',
  templateUrl: './timekeeping-detail.component.html',
  styleUrls: ['./timekeeping-detail.component.css']
})
export class TimekeepingDetailComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging ;
  listMorning =[] ;
  listAfternoon=[];
  constructor(private timeKeepingDetailService : TimeKeepingDetailService ,private toastr :ToastrService) { }

  ngOnInit(): void {
    this.loadTimeKeepingDetailMorning();
    this.loadTimeKeepingDetailAfternoon();
  }
  loadTimeKeepingDetailMorning(){
  
    this.timeKeepingDetailService.listMorning().subscribe(res => {
      this.listMorning = res.data;
      this.paging = res.paging
      console.log(this.listMorning);
   //   this.paging = res.paging;
    });
  }
  loadTimeKeepingDetailAfternoon(){
  
    this.timeKeepingDetailService.listAfternoon().subscribe(res => {
      this.listAfternoon = res.data;
      this.paging = res.paging
      console.log(this.listAfternoon);
   //   this.paging = res.paging;
    });
  }
  openEdit(timekeepingdetail : TimekeepingDetail){
    this.timeKeepingDetailService.save(timekeepingdetail).subscribe(res => {
      this.toastr.warning("Đã kết thúc ca làm" ,"Nhân viên" +timekeepingdetail.employeeId);
    
      this.loadTimeKeepingDetailMorning();
      this.loadTimeKeepingDetailAfternoon();
   //   this.paging = res.paging;
    });
  }
  removeTimeKeepingDetail(timekeepingdetail : TimekeepingDetail){
    this.timeKeepingDetailService.removeTimeKeepingDetail(timekeepingdetail).subscribe(res =>{
      this.toastr.error("Đã Xóa Ca "+timekeepingdetail.shift,"Nhân viên " +timekeepingdetail.id );
      console.log(timekeepingdetail);
      this.loadTimeKeepingDetailMorning();
      this.loadTimeKeepingDetailAfternoon();
    });
  }
}
