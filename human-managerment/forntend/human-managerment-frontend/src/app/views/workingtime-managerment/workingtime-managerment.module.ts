import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { WorkingtimeManagermentRoutingModule } from './workingtime-managerment-routing.module';
import { WorkingtimeComponent } from './workingtime.component';

import { ModalModule } from 'ngx-bootstrap/modal';

import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [WorkingtimeComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    WorkingtimeManagermentRoutingModule,
    ModalModule
  ]
})
export class WorkingtimeManagermentModule { }
