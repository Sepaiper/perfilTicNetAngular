import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { TabViewModule } from 'primeng/tabview';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from "primeng/inputtext";
import { ButtonModule } from 'primeng/button';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { PublicUserComponent } from './public-user/public-user.component';


@NgModule({
  declarations: [
    PublicUserComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    TabViewModule,
    CheckboxModule,
    InputTextModule,
    ButtonModule,
  ]
})
export class DashboardModule { }
