import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';
import { RootObj } from '../models/root-obj';
import { Login } from '../models/login';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }
  login(username: string, password: string): Observable<RootObj<Login>> {
    const data = {
      username: username,
      password: password
    };
    return this.apiService.post<RootObj<Login>>(this.apiService.apiUrl.users.login, data);
  }
  // list(): Observable<RootObj<[CustomerType]>> {
  //   return this.apiService.get<RootObj<[CustomerType]>>(this.apiService.apiUrl.customerTypes);
  // }
  // get(id): Observable<RootObj<CustomerType>> {
  //   return this.apiService.get<RootObj<CustomerType>>(`${this.apiService.apiUrl.customerTypes}/${id}`);
  // }
  // save(data: CustomerType): Observable<RootObj<CustomerType>> {
  //   if (data.id === 0) {
  //     return this.apiService.post<RootObj<CustomerType>>(this.apiService.apiUrl.customerTypes, data);
  //   } else {
  //     return this.apiService.put<RootObj<CustomerType>>(`${this.apiService.apiUrl.customerTypes}/${data.id}`, data);
  //   }
  // }
  // delete(id: number): Observable<RootObj<CustomerType>> {
  //   return this.apiService.delete<RootObj<CustomerType>>(`${this.apiService.apiUrl.customerTypes}/${id}`);
  // }
}
