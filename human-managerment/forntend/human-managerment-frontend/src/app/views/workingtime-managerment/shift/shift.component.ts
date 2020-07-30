import { Component, OnInit } from '@angular/core';
import { ShiftService } from '../../../services/shift.service';
import { Paging } from '../../../models/paging';
import { Shift } from '../../../models/shift';
import { DateUtil } from '../../../utils/date-util';

@Component({
  selector: 'app-shift',
  templateUrl: './shift.component.html',
  styleUrls: ['./shift.component.css']
})
export class ShiftComponent implements OnInit {

  shifts = [];
  choosedShift = {id:0, name: '', workStartTime: '', workEndTime:'', breakStartTime:'', breakEndTime:'', workingHoursNumber:0, workingDaysNumber:0};
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;

  shiftName = '';
  workStartTime = '';
  workEndTime = '';
  breakStartTime = '';
  breakEndTime = '';
  workingHoursNumber = 0;
  workingDaysNumber = 0;

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
    });
  }

  onRow(event) {
    if (event.type == 'click') {

      this.choosedShift = event.row;
      this.shiftName = this.choosedShift.name;
      this.workStartTime = DateUtil.getTime(this.choosedShift.workStartTime,'hh:mm:ss').toString();
      this.workEndTime = DateUtil.getTime(this.choosedShift.workEndTime,'hh:mm:ss').toString();
      this.breakStartTime = this.choosedShift.breakStartTime == null ? '' : DateUtil.getTime(this.choosedShift.breakStartTime,'hh:mm:ss').toString();
      this.breakEndTime = this.choosedShift.breakEndTime == null ? '' : DateUtil.getTime(this.choosedShift.breakEndTime,'hh:mm:ss').toString();
      this.workingHoursNumber = this.choosedShift.workingHoursNumber;
      this.workingDaysNumber = this.choosedShift.workingDaysNumber;
    }
  }

  add(){
    let newShift = {
      name : this.shiftName,
      workStartTime : DateUtil.doStringToTimeConverting(this.workStartTime),
      workEndTime : DateUtil.doStringToTimeConverting(this.workEndTime),
      breakStartTime : DateUtil.doStringToTimeConverting(this.breakStartTime),
      breakEndTime :DateUtil.doStringToTimeConverting( this.breakEndTime),
      workingHoursNumber: this.workingHoursNumber,
      workingDaysNumber : this.workingDaysNumber,
    } as Shift;

    this.shiftService.save(newShift).subscribe(res => {
      this.loadShifts();
      alert("Thêm thành công");
    });
  }

}
