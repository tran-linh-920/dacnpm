import { Injectable } from '@angular/core';
import { Department } from '../models/department';
import { Observable } from 'rxjs';
import { Paging } from '../models/paging';
import { RootObj } from '../models/root-obj';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

 
  constructor(private apiService: ApiService) { }

  list(paging: Paging): Observable<RootObj<[Department]>> {
    const query = `page=${paging.page + 1}&page_limit=${paging.pageLimit}`;
    console.log(`${this.apiService.apiUrl.departments.home}?${query}`);
    return this.apiService.get<RootObj<[Department]>>
      (`${this.apiService.apiUrl.departments.home}?${query}`);
  }
  addDepart(department: Department): Observable<RootObj<Department>> {
    return this.apiService.post(this.apiService.apiUrl.departments.home, department);
  }
}
