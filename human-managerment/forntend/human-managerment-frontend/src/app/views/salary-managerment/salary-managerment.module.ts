import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SalaryManagermentRoutingModule } from './salary-managerment-routing.module';
import { SalaryCountingComponent } from './salary-counting/salary-counting.component';
import { SalaryIncreasingComponent } from './salary-increasing/salary-increasing.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [SalaryCountingComponent, SalaryIncreasingComponent],
  imports: [
    CommonModule,
    SalaryManagermentRoutingModule,
    NgxDatatableModule,
  ]
})
export class SalaryManagermentModule { }
