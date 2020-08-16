import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TimekeepingManagermentRoutingModule } from './timekeeping-managerment-routing.module';
import { TimekeppingComponent } from './timekepping.component';
import { KeepingsComponent } from './keepings/keepings.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TimekeepingDetailComponent } from './timekeeping-detail/timekeeping-detail.component';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { TimekeepingHistoryComponent } from './timekeeping-history/timekeeping-history.component' ;
import {ToastrModule} from 'ngx-toastr'
@NgModule({
  declarations: [TimekeppingComponent, KeepingsComponent, TimekeepingDetailComponent, TimekeepingHistoryComponent],
  imports: [
    CommonModule,
    TimekeepingManagermentRoutingModule,
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule,
    TabsModule,
  //  ToastrModule.forRoot()
    
  ]
})
export class TimekeepingManagermentModule { }
