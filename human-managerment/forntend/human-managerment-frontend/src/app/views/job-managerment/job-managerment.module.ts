import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobManagermentRoutingModule } from './job-managerment-routing.module';
import { JobInfomationComponent } from './job-infomation/job-infomation.component';
import { DepartmentComponent } from './department/department.component';
import { WorkingScheduleComponent } from './working-schedule/working-schedule.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CollapseModule } from 'ngx-bootstrap/collapse';


@NgModule({
  declarations: [JobInfomationComponent, DepartmentComponent, WorkingScheduleComponent],
  imports: [
    CommonModule,
    JobManagermentRoutingModule,
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule,
    CollapseModule
  ]
})
export class JobManagermentModule { }
