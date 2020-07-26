import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LocationManagermentRoutingModule } from './location-managerment-routing.module';
import { WardComponent } from './ward/ward.component';
import { DistrictComponent } from './district/district.component';
import { ProviceComponent } from './provice/provice.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';


@NgModule({
  declarations: [WardComponent, DistrictComponent, ProviceComponent],
  imports: [
    CommonModule,
    LocationManagermentRoutingModule,
    NgxDatatableModule
  ]
})
export class LocationManagermentModule { }
