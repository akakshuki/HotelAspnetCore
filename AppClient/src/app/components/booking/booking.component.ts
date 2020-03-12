import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Regex } from 'src/app/shared/regex';
import { Booking } from 'src/app/models/booking.model';
import { ValidationService } from 'src/app/services/validation.service';
import { BookingService } from 'src/app/services/booking.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})


export class BookingComponent implements OnInit {
  @Input() dateIn: Date;
  @Input() dateOut: Date;

  booking: Booking = {
    LastName: "",
    FirstName: '',
    Email: '',
    Phone: '',
    CheckIn: new Date,
    CheckOut: new Date,
    Id: 0
  };
  form: FormGroup;
  constructor(private formbuilder: FormBuilder,
    private validationService: ValidationService,
    private bookingSerive: BookingService,
    private route : Router) { }

  ngOnInit() {
    this.form = this.formbuilder.group({
      firstName: [this.booking.FirstName, [Validators.required, Validators.maxLength(50)]],
      lastName: [this.booking.LastName, [Validators.required, Validators.maxLength(50)]],
      email: [this.booking.Email, [Validators.required, Validators.email]],
      phone: [this.booking.Phone, [Validators.required, Validators.pattern(Regex.phone)]]
    });
  }
  checkvalidation(formName: string, type: string): boolean {
    return this.validationService.validateValueForm(this.form, formName, type);
  }

  submitForm(form: FormGroup) {

    this.booking = {
      FirstName: form.value.firstName,
      LastName: form.value.lastName,
      Email: form.value.email,
      Phone: form.value.phone,
      CheckIn: this.dateIn,
      CheckOut: this.dateOut,
      Id: 0
    };
    this.bookingSerive.bookingPost(this.booking).subscribe(res => {
      alert("success");
      location.reload();
    });
  }

 
}
