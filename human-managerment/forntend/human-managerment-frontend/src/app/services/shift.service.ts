import { Injectable } from '@angular/core';
import { Paging } from '../models/paging';
import { WorkingTime } from '../models/working-time';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { ApiService } from './api.service';
import { Shift } from '../models/shift';

@Injectable({
  providedIn: 'root'
})
export class ShiftService {

  constructor(private apiService: ApiService) { }

  list(paging: Paging): Observable<RootObj<[Shift]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    console.log(`${this.apiService.apiUrl.shifts.home}?${query}`);   
    return this.apiService.get<RootObj<[Shift]>>
      (`${this.apiService.apiUrl.shifts.home}?${query}`);
  }
}
