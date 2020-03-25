import { Injectable } from '@angular/core';
import { Booking } from '../models/booking.model';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { catchError, retry } from 'rxjs/operators';
import { throwError } from 'rxjs/internal/observable/throwError';
import { error } from 'protractor';
import { BookingMv } from '../models/bookingmv.model';
import { Observable } from 'rxjs';

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
   return this.client.post(environment.baseUrl + this.object+"/guestpost", JSON.stringify(booking), { headers: this.headers })
      .pipe(catchError(this.handleError))
  }


  getBookingBySecretCode(serectCode : string): Observable<BookingMv>{
      return this.client.get<BookingMv>(environment.baseUrl + this.object+"/GetBookingByCode/"+ serectCode).pipe(retry(1));
  }
  cancelBookingBySecretCode(data: string): void {
     this.client.get<BookingMv>(environment.baseUrl +"CheckOut/CancelBooking/"+ data);
  }
}
