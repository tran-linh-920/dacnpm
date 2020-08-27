import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatExpansionModule} from '@angular/material/expansion';

import { SalaryManagermentRoutingModule } from './salary-managerment-routing.module';
import { SalaryCountingComponent } from './salary-counting/salary-counting.component';
import { SalaryIncreasingComponent } from './salary-increasing/salary-increasing.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { CollapseModule } from 'ngx-bootstrap/collapse';


@NgModule({
  declarations: [SalaryCountingComponent, SalaryIncreasingComponent],
  imports: [
    CommonModule,
    SalaryManagermentRoutingModule,
    NgxDatatableModule,
    MatExpansionModule,
    CollapseModule,
  ]
})
export class SalaryManagermentModule { }
