import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { WorkingtimeComponent } from './workingtime.component';


const routes: Routes = [
  {
    path: '',  
    data: {
      title: 'Quản lý thời gian'
    },
    children: [
      { 
        path: 'thoi-gian-lam-viec', 
        component: WorkingtimeComponent,
        data: {
          title: 'Thời gian làm việc'
        },
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkingtimeManagermentRoutingModule { }
