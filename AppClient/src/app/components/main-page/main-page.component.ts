import { Component, OnInit } from '@angular/core';

import {DaterangepickerConfig} from 'ng2-daterangepicker';


import {ActivatedRoute, NavigationEnd, Router} from '@angular/router';


@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent implements OnInit {
  public daterange: any = {};


  // see original project for full list of options
  // can also be setup using the config service to apply to multiple pickers
  public options: any = {
    autoApply: true,

    locale: {
      format: 'DD/MM/YYYY',
      daysOfWeek: [
        "CN",
        "T2",
        "T3",
        "T4",
        "T5",
        "T6",
        "T7"
      ],
      monthNames: [
        "Tháng một",
        "Tháng hai",
        "Tháng ba",
        "Tháng tư",
        "Tháng năm",
        "Tháng sáu",
        "Tháng bảy",
        "Tháng tám",
        "Tháng chín",
        "Tháng mười",
        "Tháng mười một",
        "Tháng mười hai"
      ],
    },
    alwaysShowCalendars: false,
  };
 constructor(
   private router: Router, 
   private activatedRoute: ActivatedRoute,
   private daterangepickerOptions: DaterangepickerConfig) {
   
    }

  ngOnInit() {
    $(document).on('change', 'input[type=range].multirange.ghost', function() {
      $('input[type=range].original', $(this).parent()).trigger('change');
    });

  }
  public selectedDate(value: any, datepicker?: any) {
    // this is the date the iser selected

    // any object can be passed to the selected event and it will be passed back here
    datepicker.start = value.start;
    datepicker.end = value.end;

    // or manupulat your own internal property
    this.daterange.start = value.start;
    this.daterange.end = value.end;
    this.daterange.label = value.label;
  }
}
