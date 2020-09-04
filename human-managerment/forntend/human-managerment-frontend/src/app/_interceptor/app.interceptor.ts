import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { LogUtil } from './../utils/log-util';
import { IpService } from '../services/ip.service';
import { LogService } from '../services/log.service';
import { Log } from '../models/log';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AppInterceptor implements HttpInterceptor {
    logUlti: LogUtil;
    constructor(private router: Router, private ipservice: IpService, private logService: LogService,
         private cookieService: CookieService) {
        this.logUlti = new LogUtil(this.ipservice, this.logService);
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let req = request;
         const token = this.cookieService.get('token');
         let userID = this.cookieService.get('id');
        if (!userID) {
            userID = '0';
        }
        // if (token) {
        //     req = request.clone({
        //         setHeaders: {
        //             //'Content-Type': 'application/json',
        //             'Authorization': `Bearer ${token}`
        //         }
        //     });
            console.log(req);
            this.logUlti.createLog(req, Number(userID));
        //}
        return next.handle(req).pipe(
            map((event: HttpEvent<any>) => event),
            catchError((error: HttpErrorResponse) => {
                // if (error.status === 401) {
                //     this.authService.setLoggedIn(false);
                //     this.router.navigate(['/login']);
                // }
                return throwError(error);
            })
        );
    }
    }
