import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { WorkingTimeService } from '../../services/working-time.service';
import { WorkingTime } from '../../models/working-time';
import { TimeSlotService } from '../../services/time-slot.service';
import { TimeSlot } from '../../models/time-slot';
import { Paging } from '../../models/paging';

@Component({
  selector: 'app-workingtime',
  templateUrl: './workingtime.component.html',
  styleUrls: ['./workingtime.component.css']
})
export class WorkingtimeComponent implements OnInit {

  @ViewChild('editModal', { static: false }) editModal: ModalDirective;

  workingTimes = [];
  timeSlots = [];
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;


  workingTimeForm = new FormGroup({
    name: new FormControl(''),
    bio: new FormControl(''),
    workingTimeDetails: new FormArray([]),
  });

  // workingTimeForm = this.fb.group({
  //   name: [''],
  //   bio: [''],
  //   period: [],
  // });

  constructor(
    private workingTimeService: WorkingTimeService,
    private timeSlotService: TimeSlotService,
    private fb: FormBuilder,
  ) {

  }

  ngOnInit(): void {
    this.loadWorkingTime();
    this.loadTimeSlot();
  }

  openAdd() {
    this.editModal.show();
  }

  loadWorkingTime(page = null) {
    
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.workingTimeService.list(this.paging).subscribe(res => {
      this.workingTimes = res.data;
      this.paging = res.paging;
    });
  }

  loadTimeSlot() {
    this.timeSlotService.list().subscribe(res => {
      this.timeSlots = res.data;
    });
  }

  onCheckChange(event) {
    // (this.workingTimeForm.controls.periods as FormArray).push(new FormControl(val));
    let formArray = this.workingTimeForm.controls.workingTimeDetails as FormArray;

    console.log(event);
    /*selected*/
    if (event.target.checked) {
      formArray.push(new FormControl({ "timeSlotId": parseInt(event.target.value) }));
    } else {
      // find the unselected element
      let i: number = 0;

      formArray.controls.forEach((ctrl: FormControl) => {
        if (ctrl.value == event.target.value) {
          // Remove the unselected element from the arrayForm
          formArray.removeAt(i);
          return;
        }
        i++;
      });
    }
  }

  save() {
    let workingTime = this.workingTimeForm.value;
    workingTime.id = 0;

    console.log(workingTime);


    this.workingTimeService.save(workingTime).subscribe(res => {
      this.workingTimes.push(res.data);
    });

  }

}
