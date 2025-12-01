import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MaterialModule } from './material/material.module';
import { MatIconModule } from '@angular/material/icon';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import {  NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { StoreModule } from '@ngrx/store';
import { cartReducer } from './cart/cart.reducer';
import { EffectsModule } from '@ngrx/effects';
import { CartEffects } from './cart/cart.effect';






@NgModule({
  declarations: [
    AppComponent,
  
   
    
   
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule, 
    AppRoutingModule,
    MaterialModule,
    MatIconModule,
   
   
   HttpClientModule,
    ToastrModule.forRoot(),
    NgbModule,
    NgMultiSelectDropDownModule.forRoot(),
    // StoreModule.forRoot({}, {}),
    StoreModule.forRoot({ 'cart': cartReducer }),
    EffectsModule.forRoot([CartEffects]),


    
   
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
