import { Injectable } from '@angular/core';
import { RootObj } from '../models/root-obj';
import { Log } from '../models/log';
import { Observable } from 'rxjs';


import { Paging } from '../models/paging';
import { ApiService } from './api.service';
@Injectable({
  providedIn: 'root'
})
export class LogService {

  constructor(private apiService: ApiService) { }

  listLog(paging: Paging): Observable<RootObj<[Log]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    return this.apiService.get<RootObj<[Log]>>(`${this.apiService.apiUrl.log.hone}?${query}`);
  }

  addLog(log: Log): Observable<RootObj<Log>> {
    return this.apiService.post<RootObj<Log>>(this.apiService.apiUrl.log.hone, log);
  }
}
