import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import * as bootstrap from 'bootstrap';
import * as $ from 'jquery';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
