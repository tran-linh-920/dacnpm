import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { MailForm } from './../models/mail-form';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
@Injectable({
  providedIn: 'root'
})
export class MailService {

  constructor(private apiService: ApiService) { }

  send(mail: MailForm): Observable<RootObj<MailForm>> {
    return this.apiService.post(this.apiService.apiUrl.mails.home, mail);
  }
}
