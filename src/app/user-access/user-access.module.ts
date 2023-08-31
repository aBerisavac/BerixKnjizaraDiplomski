import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserAccessRoutingModule } from './user-access-routing.module';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { RegisterComponent } from './register/register.component';


@NgModule({
  declarations: [
    LoginComponent,
    LogoutComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    UserAccessRoutingModule
  ]
})
export class UserAccessModule { }
