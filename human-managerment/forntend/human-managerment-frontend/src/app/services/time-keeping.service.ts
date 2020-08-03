import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Paging } from '../models/paging';
import { Observable, from } from 'rxjs';
import { RootObj } from '../models/root-obj';
import {Timekeeping } from '../models/timekeeping';
@Injectable({
  providedIn: 'root'
})
export class TimeKeepingService {

  constructor(private apiService: ApiService) { }

  listTimeKeeping(): Observable<RootObj<[Timekeeping]>> {
  //  const query = `page=${paging.page + 1}&page_limit=4`;
    return this.apiService.get<RootObj<[Timekeeping]>>(`${this.apiService.apiUrl.timekeeping.home}`);
  }
  save():  Observable<RootObj<[Timekeeping]>> {
   return this.apiService.post<RootObj<[Timekeeping]>>(this.apiService.apiUrl.timekeeping.creat, null);
  }
}
