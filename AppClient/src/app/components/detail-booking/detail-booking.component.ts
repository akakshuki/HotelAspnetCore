import { Component, OnInit } from '@angular/core';
import { BookingService } from 'src/app/services/booking.service';
import { BookingMv } from 'src/app/models/bookingmv.model';
import { ActivatedRoute } from '@angular/router';
import { GuestMv } from 'src/app/models/guestmv.model';

@Component({
  selector: 'app-detail-booking',
  templateUrl: './detail-booking.component.html',
  styleUrls: ['./detail-booking.component.css']
})
export class DetailBookingComponent implements OnInit {

  bookingData: BookingMv = {
    id: 0,
    guestId: 0,
    bookingDate: new Date(),
    checkIn: new Date(),
    checkOut: new Date(),
    durationStay: 0,
    secretCode: '',
    status: '',
    amount: 0,
    guestMv: {
      id: 0,
      firstName: '',
      lastName: '',
      phone: '',
      email: '',
      identityNo: ''
    }
};


constructor(private service : BookingService, private route: ActivatedRoute) { }



ngOnInit() {
  this.getBooking();
}

getBooking(){
  var data = this.route.snapshot.paramMap.get("id");
  this.service.getBookingBySecretCode(data).subscribe(res =>this.bookingData = res) 
}
CancelBooking(){
  var data = this.route.snapshot.paramMap.get("id");
  this.service.cancelBookingBySecretCode(data)
}
}
