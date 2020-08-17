import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { HttpClient } from '@angular/common/http';
import { Paging } from '../models/paging';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { SalaryHistory } from '../models/salary-history';

@Injectable({
  providedIn: 'root'
})
export class SalaryService {

  constructor(private apiService: ApiService, private http: HttpClient) { }

  histories(paging: Paging): Observable<RootObj<[SalaryHistory]>> {
    const query = `page=${paging.page}&page_limit=${paging.pageLimit}`;
    console.log(`${this.apiService.apiUrl.salary.histories}?${query}`);
    return this.apiService.get<RootObj<[SalaryHistory]>>
      (`${this.apiService.apiUrl.salary.histories}?${query}`);
  }

  count(date: object): Observable<RootObj<object>> {
    console.log(`${this.apiService.apiUrl.salary.counting}`);
    return this.apiService.post<RootObj<object>>(this.apiService.apiUrl.salary.counting, date);
  }

  increase(empId: number, jobLevel: number): Observable<RootObj<number>> {
    var url = `${this.apiService.apiUrl.salary.increasing}/${empId}/${jobLevel}`;
    console.log(url);
    return this.apiService.put<RootObj<number>>(url, null);
  }

}
