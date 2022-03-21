import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PreviteGuardGuard } from './previte-guard.guard';

const routes: Routes = [
  {
    path: 'dashboard',
    loadChildren: () => import('./components/dashboard/dashboard.module').then(m => m.DashboardModule),
  },
  {
    path: 'login',
    loadChildren: () => import('./components/login/login.module').then(m => m.LoginModule),
  },
  {
    path: 'home/:token',
    loadChildren: () => import('./components/home/home.module').then(m => m.HomeModule),
    canActivate: [PreviteGuardGuard]
  },
  {
    path: '**',
    redirectTo: 'dashboard'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
