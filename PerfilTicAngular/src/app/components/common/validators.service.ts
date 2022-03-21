import { Injectable } from '@angular/core';
import { AbstractControl, ValidationErrors } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class ValidatorsService {
  public emailPattern: string | RegExp = new RegExp(/^(([^<>()[\]\.,;:\s@\"]+(\.[^<>()[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/);
  public passwordPattern: string | RegExp = new RegExp(/^[A-Za-z\d!@#&()_+.]*$/);
  public numberDocumentPassPattern: string | RegExp = new RegExp(/^[A-Za-z\d]*$/);
  public numberDocumentPattern: string | RegExp = new RegExp(/^[0-9]*$/);
  public alphabeticalPattern: string | RegExp = new RegExp(/(^[a-zA-ZÀ-ÿ\u00f1\u00d1]+([a-zA-ZÀ-ÿ\u00f1\u00d1\s.])*)$/);
  public alphaNumeric: string | RegExp = new RegExp(/(^[a-zA-ZÀ-ÿ\u00f1\u00d1\d]+([a-zA-ZÀ-ÿ\u00f1\u00d1\s.\d])*)$/);
  public citylPattern: RegExp = new RegExp(/^[a-zA-ZÀ-ÿ\-]+([a-zA-ZÀ-ÿ\u00f1\u00d1\s.)+([a-zA-ZÀ-ÿ\u00f1\u00d1\s.])*$/);
  public expRegSearch = new RegExp(/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\d!@#&()/_+.:{}]+(?: [a-zA-ZáéíóúÁÉÍÓÚñÑ\d!@#&()/_+.:{}]+)*$/,);

  constructor() { }
}
