import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Paging } from '../models/paging';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { Degree } from '../models/degree';

@Injectable({
  providedIn: 'root'
})
export class DegreeService {

  constructor(private apiService: ApiService) { }

  list(paging: Paging): Observable<RootObj<[Degree]>> {
    const query = `page=${paging.page + 1}&page_limit=${paging.pageLimit}`;
    console.log(`${this.apiService.apiUrl.degrees.home}?${query}`);   
    return this.apiService.get<RootObj<[Degree]>>
      (`${this.apiService.apiUrl.degrees.home}?${query}`);
  }
}
