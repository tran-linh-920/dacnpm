import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { WorkingTime } from '../models/working-time';
import { Paging } from '../models/paging';

@Injectable({
  providedIn: 'root'
})
export class WorkingTimeService {

  constructor(private apiService: ApiService) { }

  list(paging: Paging): Observable<RootObj<[WorkingTime]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    console.log(`${this.apiService.apiUrl.workingTimes.home}&${query}`);   
    return this.apiService.get<RootObj<[WorkingTime]>>
      (`${this.apiService.apiUrl.workingTimes.home}?${query}`);
  }

  save(data: WorkingTime): Observable<RootObj<WorkingTime>> {
    if (data.id === 0) {
      return this.apiService.post<RootObj<WorkingTime>>(this.apiService.apiUrl.workingTimes.home, data);
    } else {
      return this.apiService.put<RootObj<WorkingTime>>(`${this.apiService.apiUrl.workingTimes.home}/${data.id}`, data);
    }
  }

  // list(page: Page): Observable<RootObj<[Customer]>> {
  //   const queryString = `p=${page.pageNumber}&s=${page.pageSize}`;
  //   return this.apiService.get<RootObj<[Customer]>>
  //     (`${this.apiService.apiUrl.customers.home}?${queryString}`);
  // }
  // listByCustomerType(id: number, page: Page): Observable<RootObj<[Customer]>> {
  //   const queryString = `p=${page.pageNumber}&s=${page.pageSize}`;
  //   return this.apiService.get<RootObj<[Customer]>>
  //     (`${this.apiService.apiUrl.customers.listByType}/${id}?${queryString}`);
  // }
  // get(id): Observable<RootObj<Customer>> {
  //   return this.apiService.get<RootObj<Customer>>(`${this.apiService.apiUrl.customers.home}/${id}`);
  // }

  // save(data: Customer): Observable<RootObj<Customer>> {
  //   if (data.id === 0) {
  //     return this.apiService.post<RootObj<Customer>>(this.apiService.apiUrl.customers.home, data);
  //   } else {
  //     return this.apiService.put<RootObj<Customer>>(`${this.apiService.apiUrl.customers.home}/${data.id}`, data);
  //   }
  // }
  // delete(id: number): Observable<RootObj<Customer>> {
  //   return this.apiService.delete<RootObj<Customer>>(`${this.apiService.apiUrl.customers.home}/${id}`);
  // }
}
