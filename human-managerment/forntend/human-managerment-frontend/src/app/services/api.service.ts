import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  constructor(private http: HttpClient) {
  }
  baseUrl = 'http://localhost:50618/';
  apiUrl = {
    employees: {
      home: `${this.baseUrl}employees`,
      images: `${this.baseUrl}uploads/images/employees/`,
      canimg: `${this.baseUrl}uploads/images/candidates/`


    },
    candidates: {
      home: `${this.baseUrl}candidates`,
      type: `${this.baseUrl}candidates/type`,

    },
    notes: {
      home: `${this.baseUrl}notes`,
    },
    mails:{
      home: `${this.baseUrl}mails`,
    },
    departments: {
      home: `${this.baseUrl}departments`
    },
    degrees: {
      home: `${this.baseUrl}degrees`
    },
    shifts: {
      home: `${this.baseUrl}shifts`
    },
    workingTimes: {
      home: `${this.baseUrl}working-times`
    },
    timeSlots: {
      home: `${this.baseUrl}time-slots`
    },
    location:{
      province: `${this.baseUrl}addresses/province`,
      district: `${this.baseUrl}addresses/district`,
      ward: `${this.baseUrl}addresses/ward`,
      address: `${this.baseUrl}addresses/address`
    },
    timekeeping: {
      home: `${this.baseUrl}time-keepings`,
      creat: `${this.baseUrl}time-keepings`
    },
    schedule: {
      home: `${this.baseUrl}schedules`,
    }
  };

  get<T>(url: string): Observable<T> {
    return this.http.get<T>(url);
  }
  post<T>(url: string, data: Object): Observable<T> {
    return this.http.post<T>(url, data);
  }
  put<T>(url: string, data: Object): Observable<T> {
    return this.http.put<T>(url, data);
  }
  delete<T>(url: string): Observable<T> {
    return this.http.delete<T>(url);
  }
}
