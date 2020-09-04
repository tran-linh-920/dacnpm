
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthenticationInterceptor implements HttpInterceptor {
    constructor(private router: Router, private authService: AuthService) {}
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let req = request;
        const token = localStorage.getItem('token');
        if (token) {
            req = request.clone({
                setHeaders: {
                    'Content-Type': 'application/json',
                    'Authorization': `Bearer ${token}`
                }
            });
        }
        return next.handle(req).pipe(
            map((event: HttpEvent<any>) => event ),
            catchError((error: HttpErrorResponse) => {
                console.log(error);
                if (error.status === 401) {
                    this.authService.setLoggedIn(false);
                    this.router.navigate(['/login']);
                }
                // ở đây là trường hợp người dùng không có quyền truy cập
                if (error.status === 500) {
                    this.router.navigate(['/500']);
                }
                return throwError(error);
            })
        );
    }
}