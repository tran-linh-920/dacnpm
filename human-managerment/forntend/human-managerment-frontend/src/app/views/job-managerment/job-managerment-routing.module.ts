import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobInfomationComponent } from './job-infomation/job-infomation.component';
import { DepartmentComponent } from './department/department.component';
import { WorkingScheduleComponent } from './working-schedule/working-schedule.component';


const routes: Routes = [ {
  path: '',  
  data: {
    title: 'Quản lý công việc'
  },
  children: [
    { 
      path: 'thong-tin-cong-viec', 
      component: JobInfomationComponent,
      data: {
        title: 'Thông tin công việc'
      },
    },
    { 
      path: 'phong-ban', 
      component: DepartmentComponent,
      data: {
        title: 'Phòng ban'
      },
    },
    { 
      path: 'lich-cong-tac', 
      component: WorkingScheduleComponent,
      data: {
        title: 'Lịch công tác'
      },
    },
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class JobManagermentRoutingModule { }
