import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SalaryCountingComponent } from './salary-counting/salary-counting.component';
import { SalaryIncreasingComponent } from './salary-increasing/salary-increasing.component';


const routes: Routes = [
  {
    path: '',  
    data: {
      title: 'Quản lý lương'
    },
    children: [
      { 
        path: 'tinh-luong', 
        component: SalaryCountingComponent,
        data: {
          title: 'Tính lương'
        },
      },
      { 
        path: 'nang-luong', 
        component: SalaryIncreasingComponent,
        data: {
          title: 'Nâng lương'
        },
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SalaryManagermentRoutingModule { }
