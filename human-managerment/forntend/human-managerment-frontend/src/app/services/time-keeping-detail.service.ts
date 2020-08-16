import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { TimekeepingDetail } from '../models/timekeeping-detail';

@Injectable({
  providedIn: 'root'
})
export class TimeKeepingDetailService {

  constructor(private apiService: ApiService) { }
  removeTimeKeepingDetail(data: TimekeepingDetail):Observable<RootObj<[TimekeepingDetail]>> {
    return this.apiService.delete<RootObj<[TimekeepingDetail]>>(`${this.apiService.apiUrl.timeKeepingDetail.home}/${data.id}`);
  }
  listTimeKeepingDetail():Observable<RootObj<[TimekeepingDetail]>> {
    return this.apiService.get<RootObj<[TimekeepingDetail]>>(`${this.apiService.apiUrl.timeKeepingDetail.home}`);
  }
  listMorning():Observable<RootObj<[TimekeepingDetail]>> {
    return this.apiService.get<RootObj<[TimekeepingDetail]>>(`${this.apiService.apiUrl.timeKeepingDetail.monrning}`);
  }
  listAfternoon():Observable<RootObj<[TimekeepingDetail]>> {
    return this.apiService.get<RootObj<[TimekeepingDetail]>>(`${this.apiService.apiUrl.timeKeepingDetail.afteroon}`);
  }

  save(data: TimekeepingDetail): Observable<RootObj<TimekeepingDetail>> {
   console.log(data);
    return this.apiService.put<RootObj<TimekeepingDetail>>(`${this.apiService.apiUrl.timeKeepingDetail.home}/${data.id}`, data);
  }
}
