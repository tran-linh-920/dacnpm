import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkingtimeManagermentRoutingModule } from './workingtime-managerment-routing.module';
import { WorkingtimeComponent } from './workingtime.component';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ReactiveFormsModule } from '@angular/forms';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ShiftComponent } from './shift/shift.component';

import { TimepickerModule } from 'ngx-bootstrap/timepicker';

@NgModule({
  declarations: [WorkingtimeComponent, ShiftComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    WorkingtimeManagermentRoutingModule,
    ModalModule,
    TimepickerModule,
    NgxDatatableModule,
  ]
})
export class WorkingtimeManagermentModule { }
