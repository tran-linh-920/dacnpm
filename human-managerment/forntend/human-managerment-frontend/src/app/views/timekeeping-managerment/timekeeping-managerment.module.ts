import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimekeepingManagermentRoutingModule } from './timekeeping-managerment-routing.module';
import { TimekeppingComponent } from './timekepping.component';


@NgModule({
  declarations: [TimekeppingComponent],
  imports: [
    CommonModule,
    TimekeepingManagermentRoutingModule
  ]
})
export class TimekeepingManagermentModule { }
