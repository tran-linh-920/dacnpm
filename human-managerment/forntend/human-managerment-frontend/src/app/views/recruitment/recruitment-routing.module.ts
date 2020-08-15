import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CandidateComponent } from './candidate/candidate.component';
import { AddCandidateComponent } from './add-candidate/add-candidate.component';
import { InfoCandidateComponent } from './info-candidate/info-candidate.component';
import { ScheduleComponent } from './schedule/schedule.component';
import { AcceptCandidateComponent } from './accept-candidate/accept-candidate.component';
import { DeclineCandidateComponent } from './decline-candidate/decline-candidate.component';

const routes: Routes = [
  { 
    path: '',
    data: {
      title: 'Tuyển dụng'
    },
    children: [
      { 
        path: 'tuyen-nhan-su',
        component: CandidateComponent,
        data: {
          title: 'Danh sách ứng viên'
        },
      },
      {
        path: 'add',
        component: AddCandidateComponent,
        data: {
          title: 'Thêm ứng viên'
        },
      },
      {
        path: 'info/:id',
        component: InfoCandidateComponent,
        data: {
          title: 'Thông tin ứng viên'
        },
      },
      {
        path: 'schedule',
        component: ScheduleComponent,
        data: {
          title: 'lịch hẹn'
        },
      },
      {
        path: 'chap-nhan',
        component: AcceptCandidateComponent,
        data: {
          title: 'thỏa thuận'
        },
      },
      {
        path: 'huy-bo',
        component: DeclineCandidateComponent,
        data: {
          title: 'không đạt yêu cầu'
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruitmentRoutingModule { }
