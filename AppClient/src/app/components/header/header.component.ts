import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { from } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  formSecretCode: FormGroup;

  constructor(private fb: FormBuilder, private route: Router) { }

  ngOnInit() {
    this.formSecretCode = this.fb.group({
      searchInput: new FormControl()
    });
  }

  searchBooking(form: FormGroup) {

    this.route.navigate(['booking/' + form.value.searchInput]);
  }

}
