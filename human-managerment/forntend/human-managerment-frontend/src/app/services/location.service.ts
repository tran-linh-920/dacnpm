import { Injectable } from '@angular/core';
import { RootObj } from '../models/root-obj';
import { Province } from '../models/province';
import { District } from '../models/district';
import { Ward } from '../models/ward';
import { Observable } from 'rxjs';


import { Paging } from '../models/paging';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private apiService: ApiService) { }

  listProvince(paging: Paging): Observable<RootObj<[Province]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    return this.apiService.get<RootObj<[Province]>>(`${this.apiService.apiUrl.location.province}?${query}`);
  }

  listDistrict(paging: Paging): Observable<RootObj<[District]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    return this.apiService.get<RootObj<[District]>>(`${this.apiService.apiUrl.location.district}?${query}`);
  }

  listWard(paging: Paging): Observable<RootObj<[Ward]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    return this.apiService.get<RootObj<[Ward]>>(`${this.apiService.apiUrl.location.ward}?${query}`);
  }

  addWard(ward: Ward): Observable<RootObj<Ward>> {
    return this.apiService.post<RootObj<Ward>>(this.apiService.apiUrl.location.ward, ward);
  }
}
