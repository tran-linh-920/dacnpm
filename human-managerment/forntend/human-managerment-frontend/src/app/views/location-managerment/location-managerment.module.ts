import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
    NgxDatatableModule,
    ModalModule.forChild(),
    FormsModule, 
    ReactiveFormsModule,
  ]
})
export class LocationManagermentModule { }
