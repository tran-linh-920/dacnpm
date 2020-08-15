import { Component, OnInit } from '@angular/core';
import { DayService, WeekService, WorkWeekService, MonthService,
   AgendaService, EventSettingsModel } from '@syncfusion/ej2-angular-schedule';
import { ScheduleService } from './../../../services/schedule.service';
import { Schedule } from './../../../models/schedule';
@Component({
  selector: 'app-schedule',
  providers: [DayService, WeekService, WorkWeekService, MonthService, AgendaService],
  template: `<ejs-schedule width='100%' height='550px' [selectedDate]="selectedDate"
  [eventSettings]="eventSettings"> </ejs-schedule>`,
  //templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {
  schedules: Schedule[] = [];
  public data: object [] = [];
//   public data: object [] = [{
//     Id: 2,
//     EventName: 'Meeting',
//     StartTime: new Date(2020, 7, 15, 13, 0),
//     EndTime: new Date(2020, 7, 15,  15, 0),
//     IsAllDay: false,
//   },{
//     Id: 3,
//     EventName: 'Meeting 12345',
//     StartTime: new Date(2020, 7, 15, 16, 0),
//     EndTime: new Date(2020, 7, 15,  17, 0),
//     IsAllDay: false,
//   },
// ];
  public selectedDate: Date = new Date();
  public eventSettings: EventSettingsModel;
  constructor(private scheduleService: ScheduleService) { }

  ngOnInit(): void {
    this.scheduleService.list().subscribe(res => {
      this.schedules = res.data;
      console.log(this.schedules);
      for (let index = 0; index < this.schedules.length; index++) {
       this.data[index] = {
        Id: index,
        EventName: 'Phỏng vấn ' + this.schedules[index].canName,
        StartTime: this.schedules[index].interviewDate,
        EndTime: this.schedules[index].interviewDate,
       // EndTime: new Date(this.schedules[index].interviewDate.getFullYear(), this.schedules[index].interviewDate.getMonth(), this.schedules[index].interviewDate.getDay(),  this.schedules[index].interviewDate.getHours(), this.schedules[index].interviewDate.getMinutes()),
        IsAllDay: false,
      };
     this.eventSettings = {
        dataSource: this.data,
        fields: {
          id: 'Id',
          subject: { name: 'EventName' },
          isAllDay: { name: 'IsAllDay' },
          startTime: { name: 'StartTime' },
        }
      };
      }
    });
  }

}
