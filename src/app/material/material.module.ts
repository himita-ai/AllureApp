import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatSidenavModule} from '@angular/material/sidenav'
import {MatListModule} from '@angular/material/list'; 
import { MatIconModule } from '@angular/material/icon';
import {MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatSidenavModule,
    MatListModule
  ],
  exports: [
    CommonModule,
    MatSidenavModule,
    MatListModule,
    MatIconModule,
    MatTableModule 
  ]
})
export class MaterialModule { }