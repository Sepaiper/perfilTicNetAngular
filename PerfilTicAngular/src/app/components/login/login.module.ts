import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { TabViewModule } from 'primeng/tabview';
import { CheckboxModule } from 'primeng/checkbox';
import { InputTextModule } from "primeng/inputtext";
import { ButtonModule } from 'primeng/button';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login/login.component';


@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule,
    LoginRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    TabViewModule,
    CheckboxModule,
    InputTextModule,
    ButtonModule,
  ]
})
export class LoginModule { }
