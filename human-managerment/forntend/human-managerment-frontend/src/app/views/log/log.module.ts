import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LogRoutingModule } from './log-routing.module';
import { LogComponent } from './log.component';

import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [LogComponent],
  imports: [
    CommonModule,
    LogRoutingModule,
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule,
  ]
})
export class LogModule { }
