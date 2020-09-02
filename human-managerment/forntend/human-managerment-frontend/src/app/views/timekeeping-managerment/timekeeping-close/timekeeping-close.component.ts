import { Component, OnInit } from '@angular/core';
import { TimeKeepingService } from '../../../services/time-keeping.service';

@Component({
  selector: 'app-timekeeping-close',
  templateUrl: './timekeeping-close.component.html',
  styleUrls: ['./timekeeping-close.component.css']
})
export class TimekeepingCloseComponent implements OnInit {
  listClose = [] ;
  constructor(private timeKeepingService :TimeKeepingService) { }

  ngOnInit(): void {
    this.load();
  }
  load(){
    this.timeKeepingService.listcloseTimeKeeping().subscribe(res =>{
      this.listClose = res.data;
      console.log(res);
    });
  }
}
