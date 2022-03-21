import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Observable, } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService {

  constructor(
    // private loadingService: LoadingService,
    // private msgService: MsgService
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log(req)
    // this.loadingService.show();
    const tokenLocal = localStorage.getItem('token');
    const tokenSession = sessionStorage.getItem('token');
    const headers = req.clone({
      url: `${req.url}`,
      headers: req.headers.set('Authorization', `Bearer ${tokenLocal || tokenSession}`)
    });
    return next.handle(headers).pipe(
      tap({
        next: x => { console.log(x) },
        error: err => { console.log(err) },
      }))

    //   (event: HttpEvent<any>) => {
    //     if (event instanceof HttpResponse) {
    //       this.loadingService.hide();
    //       if (event.body) {
    //         this.msgService.notify(event.body.severities, event.body.summary, event.body.detail, event.body.errors, event.body.viewToast);
    //       }
    //     }
    //   },
    //   (error: HttpErrorResponse) => {
    //     this.loadingService.hide();
    //     if (error.error) {
    //       this.msgService.notify(error.error.severities, error.error.summary, error.error.detail, error.error.errors, error.error.viewToast);
    //     }
    //   }
    // ),

  }
}
