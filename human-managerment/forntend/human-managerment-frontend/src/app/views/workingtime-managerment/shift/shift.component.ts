import { Component, OnInit } from '@angular/core';
import { ShiftService } from '../../../services/shift.service';
import { Paging } from '../../../models/paging';

@Component({
  selector: 'app-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {

  shifts = [];
  timeSlots = [];
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  myTime: Date = new Date();

  constructor(
    private shiftService: ShiftService,
  ) { }

  ngOnInit(): void {
    this.loadShifts();
  }

  loadShifts(page = null) {
    
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.shiftService.list(this.paging).subscribe(res => {
      this.shifts = res.data;
      this.paging = res.paging;
      console.log( res.paging);
    });
  }

}
