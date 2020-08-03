import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TimekeppingComponent } from './timekepping.component';
import { KeepingsComponent } from './keepings/keepings.component';


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
       
    }]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TimekeepingManagermentRoutingModule { }
