import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Paging } from '../models/paging';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { Degree } from '../models/degree';
import { HttpClient, HttpRequest,} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DegreeService {

  constructor(private apiService: ApiService, private http: HttpClient) { }

  list(paging: Paging): Observable<RootObj<[Degree]>> {
    const query = `page=${paging.page + 1}&page_limit=${paging.pageLimit}`;
    console.log(`${this.apiService.apiUrl.degrees.home}?${query}`);   
    return this.apiService.get<RootObj<[Degree]>>
      (`${this.apiService.apiUrl.degrees.home}?${query}`);
  }

  addDegree(file: File, degreeeId: number, employeeId: number): Observable<any>{
    const formData: FormData = new FormData();
    formData.append('UploadedFile', file);
    formData.append('DegreeTypeId',degreeeId.toString());
    formData.append('EmployeeId', employeeId.toString());
  
    const req = new HttpRequest('POST', this.apiService.apiUrl.degrees.home, formData);

    return this.http.request(req);
  }
}
