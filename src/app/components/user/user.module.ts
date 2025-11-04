import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserHeaderComponent } from './shared/user-header/user-header.component';
import { UserFooterComponent } from './shared/user-footer/user-footer.component';
import { UserLayoutComponent } from './pages/user-layout/user-layout.component';


@NgModule({
  declarations: [
    UserLayoutComponent,
    UserHeaderComponent,
    UserFooterComponent
   
  ],
  imports: [
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
