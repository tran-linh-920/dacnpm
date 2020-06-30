import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { TimeSlot } from '../models/time-slot';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';

@Injectable({
  providedIn: 'root'
})
export class TimeSlotService {

  constructor(private apiService: ApiService) { }

  list(): Observable<RootObj<[TimeSlot]>> {
    return this.apiService.get<RootObj<[TimeSlot]>>
      (`${this.apiService.apiUrl.timeSlots.home}`);
  }

}
