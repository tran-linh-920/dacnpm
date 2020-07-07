import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WardComponent } from './ward/ward.component';
import { DistrictComponent } from './district/district.component';
import { ProviceComponent } from './provice/provice.component';


const routes: Routes = [{
  path: '',  
  data: {
    title: 'Quản lý vị trí'
  },
  children: [
    { 
      path: 'phuong-xa', 
      component: WardComponent,
      data: {
        title: 'Phường - Xã'
      },
    },
    { 
      path: 'quan-huyen', 
      component: DistrictComponent,
      data: {
        title: 'Quận - Huyện'
      },
    },
    { 
      path: 'tinh-thanh-pho', 
      component: ProviceComponent,
      data: {
        title: 'Tỉnh - Thành phố'
      },
    },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LocationManagermentRoutingModule { }
