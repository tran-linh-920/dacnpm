import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IpService {
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
   });
  constructor(private http: HttpClient) { }

  public getIPAddress(): Observable<any> {
    return this.http.get('https://cors-anywhere.herokuapp.com/http://api.ipify.org/?format=json', { headers: this.headers});
  }
}
