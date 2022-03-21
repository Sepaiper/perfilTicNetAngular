import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PreviteGuardGuard implements CanActivate {
  constructor() { }

  canActivate(router: ActivatedRouteSnapshot): Observable<boolean> | boolean {
    const token: string = (router.params) ? router.params['token'] : '1';
    localStorage.setItem('token', token);
    sessionStorage.setItem('token', token);
    return (token) ? true : false;
  }
  
}
