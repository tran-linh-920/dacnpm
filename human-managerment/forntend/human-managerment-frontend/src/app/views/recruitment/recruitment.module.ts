import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { RecruitmentRoutingModule } from './recruitment-routing.module';
import { CandidateComponent } from './candidate/candidate.component';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { InfoCandidateComponent } from './info-candidate/info-candidate.component';
import {ScheduleModule, RecurrenceEditorModule, DayService, WeekService, WorkWeekService, MonthService, AgendaService } from '@syncfusion/ej2-angular-schedule';
import { ScheduleComponent } from './schedule/schedule.component';
import { AcceptCandidateComponent } from './accept-candidate/accept-candidate.component';
import { DeclineCandidateComponent } from './decline-candidate/decline-candidate.component';


@NgModule({
  declarations: [CandidateComponent, AddCandidateComponent, InfoCandidateComponent, ScheduleComponent, AcceptCandidateComponent, DeclineCandidateComponent],
  imports: [
    CommonModule,
    TabsModule,
    RecruitmentRoutingModule,
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule,
    ScheduleModule, 
    RecurrenceEditorModule,
  ],
  providers: [DayService, WeekService, WorkWeekService, MonthService, AgendaService ]
})
export class RecruitmentModule { }
