import { Injectable } from '@angular/core';
import { ApiService } from './../services/api.service';
import { Schedule } from '../models/schedule';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  constructor(private apiService: ApiService) { }

  save(schedule: Schedule): Observable<RootObj<Schedule>> {
    return this.apiService.post(this.apiService.apiUrl.schedule.home, schedule);
  }

  list(): Observable<RootObj<[Schedule]>> {
    return this.apiService.get(this.apiService.apiUrl.schedule.home);
  }
}
