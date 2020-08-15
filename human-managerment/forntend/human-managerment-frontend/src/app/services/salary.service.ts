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
    const query = `page=${paging.page + 1}&page_limit=4`;
    console.log(`${this.apiService.apiUrl.salary.histories}?${query}`);
    return this.apiService.get<RootObj<[SalaryHistory]>>
      (`${this.apiService.apiUrl.salary.histories}?${query}`);
  }
}
