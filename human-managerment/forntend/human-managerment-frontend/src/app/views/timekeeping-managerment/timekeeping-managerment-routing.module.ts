import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimekeppingComponent } from './timekepping.component';


const routes: Routes = [
  { 
    path: '', 
    component: TimekeppingComponent,
    data: {
      title: 'Quản lý chấm công'
    },
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimekeepingManagermentRoutingModule { }
