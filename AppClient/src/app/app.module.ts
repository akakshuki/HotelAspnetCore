import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Daterangepicker } from 'ng2-daterangepicker';
import { HttpClientModule,  } from '@angular/common/http';

import * as bootstrap from 'bootstrap';
import * as $ from 'jquery';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from '../app/components/header/header.component';
import { FooterComponent } from '../app/components/footer/footer.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { BookingComponent } from './components/booking/booking.component';
import { CategoryroomComponent } from './components/categoryroom/categoryroom.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainPageComponent,
    BookingComponent,
    CategoryroomComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule, 
    FormsModule,
    HttpClientModule,
    Daterangepicker

  ],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
