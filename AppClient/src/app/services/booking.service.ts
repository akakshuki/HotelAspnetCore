import { Injectable } from '@angular/core';
import { Booking } from '../models/booking.model';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs/internal/observable/throwError';
import { error } from 'protractor';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  booking: Booking;

  private object: string;
  private headers: HttpHeaders;

  constructor(private client: HttpClient) {
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
    this.object = "Booking";
  }

  private handleError(error: any) {
    console.log(error);
    return throwError(error);
  }

  bookingPost(booking: Booking) {
    var data = JSON.stringify(booking);
    console.log(data);
   return this.client.post(environment.baseUrl + this.object, JSON.stringify(booking), { headers: this.headers })
      .pipe(catchError(this.handleError))
  }

}
