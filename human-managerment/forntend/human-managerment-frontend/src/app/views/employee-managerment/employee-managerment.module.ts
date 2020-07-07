import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeManagermentRoutingModule } from './employee-managerment-routing.module';
import { BasicInfoComponent } from './basic-info/basic-info.component';
import { DegreeComponent } from './degree/degree.component';
import { IdentificationComponent } from './identification/identification.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';

@NgModule({
  declarations: [BasicInfoComponent, DegreeComponent, IdentificationComponent],
  imports: [
    CommonModule,
    EmployeeManagermentRoutingModule,
    TabsModule,
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule
  ]
})
export class EmployeeManagermentModule { }
