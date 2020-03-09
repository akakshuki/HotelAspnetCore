import { Injectable } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidationService {

  constructor() { }


  private getFormControlName(formControllName: string, formGroup: FormGroup) {
    return formGroup.get(formControllName);
  }

  //check validateform with  form goup name, form controll name and type validate of this form
  validateValueForm(formGroup: FormGroup, formName: string, type: string) {
    var formControl = this.getFormControlName(formName, formGroup);
    if (formControl.dirty || formControl.touched) {
      return formControl.hasError(type);
    } else {
      return false;
    }

  }
}