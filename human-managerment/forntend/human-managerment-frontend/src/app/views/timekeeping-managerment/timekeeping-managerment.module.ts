import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimekeepingManagermentRoutingModule } from './timekeeping-managerment-routing.module';
import { TimekeppingComponent } from './timekepping.component';
import { KeepingsComponent } from './keepings/keepings.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [TimekeppingComponent, KeepingsComponent],
  imports: [
    CommonModule,
    TimekeepingManagermentRoutingModule,
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule
  ]
})
export class TimekeepingManagermentModule { }
