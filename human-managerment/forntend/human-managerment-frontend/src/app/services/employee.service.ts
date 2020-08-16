import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { Paging } from '../models/paging';
import { Employee } from '../models/employee';
import { ApiService } from './api.service';
import { HttpClient, HttpRequest, HttpHeaders, HttpEvent } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private apiService: ApiService, private http: HttpClient) { }

  list(paging: Paging): Observable<RootObj<[Employee]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    console.log(`${this.apiService.apiUrl.employees.home}?${query}`);
    return this.apiService.get<RootObj<[Employee]>>
      (`${this.apiService.apiUrl.employees.home}?${query}`);
  }

  addEmployee(file: File, employee: Employee): Observable<any>{
    const formData: FormData = new FormData();
    formData.append('UploadedFile', file);
    formData.append('Firstname', employee.firstname );
    formData.append('Lastname', employee.lastname);
    formData.append('BirthDay', employee.birthDay.toString());
    formData.append('Gender', employee.gender + '');
    formData.append('Email', employee.email );
    formData.append('PhoneNumber', employee.phoneNumber);
    formData.append('HireDay', employee.hireDay.toString() );
    formData.append('Salary', employee.jobLevel + '');
    formData.append('ImageName', '');

    const req = new HttpRequest('POST', this.apiService.apiUrl.employees.home, formData);

    return this.http.request(req);
  }

  jobInformations(paging: Paging): Observable<RootObj<[Employee]>> {
    const query = `page=${paging.page}&page_limit=${paging.pageLimit}`;
    console.log(`${this.apiService.apiUrl.employees.jobInformations}?${query}`);
    return this.apiService.get<RootObj<[Employee]>>
      (`${this.apiService.apiUrl.employees.jobInformations}?${query}`);
  }
}
