import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  async loginRequest(login: any) {
    const url = `http://localhost:17661/api/ReadAdmin`;
    return this.http.post<{token: string}>(url, login);
  }
}
