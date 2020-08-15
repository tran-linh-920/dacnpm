import { Component, OnInit } from '@angular/core';
import { TimeKeepingDetailService } from '../../../services/time-keeping-detail.service';
import { Paging } from '../../../models/paging';

@Component({
  selector: 'app-timekeeping-history',
  templateUrl: './timekeeping-history.component.html',
  styleUrls: ['./timekeeping-history.component.css']
})
export class TimekeepingHistoryComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  listTimeKeepingDetail =[];
  constructor(private timeKeepingDetailService : TimeKeepingDetailService ) { }

  ngOnInit(): void {
    this.loadTimeKeepingDetailHistory();
  }
  loadTimeKeepingDetailHistory(){
    this.timeKeepingDetailService.listTimeKeepingDetail().subscribe(res => {
        this.listTimeKeepingDetail = res.data;
        console.log(this.listTimeKeepingDetail);
    });
  }
}
