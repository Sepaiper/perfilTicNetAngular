import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublicUserComponent } from './public-user/public-user.component';

const routes: Routes = [{
  path: '',
  children: [
    {
      path: '',
      component: PublicUserComponent
    },
    {
      path: '**',
      redirectTo: ''
    }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
