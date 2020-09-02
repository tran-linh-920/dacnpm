import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimekeppingComponent } from './timekepping.component';
import { KeepingsComponent } from './keepings/keepings.component';
import {TimekeepingDetailComponent} from './timekeeping-detail/timekeeping-detail.component';
import { TimekeepingHistoryComponent } from './timekeeping-history/timekeeping-history.component';
import { TimekeepingCloseComponent } from './timekeeping-close/timekeeping-close.component';

const routes: Routes = [
  { 
    path: '', 
    data: {
      title: 'Quản lý chấm công'
    },
    children:[
        { 
          path: 'cham-cong', 
          component: KeepingsComponent,
          data: {
            title: 'Chấm công '
          },
        },
        {
          path :'cham-cong-chitiet',
          component: TimekeepingDetailComponent,
          data:{
            title :'chi tiet'
          }
        },
        {
          path :'cham-cong-lichsu',
          component: TimekeepingHistoryComponent,
          data:{
            title :'lichsu'
          }
        },
      {
        path :'cham-cong-close',
          component: TimekeepingCloseComponent,
          data:{
            title :'bảng công đã đóng'
          }
      }
     
  ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimekeepingManagermentRoutingModule { }
