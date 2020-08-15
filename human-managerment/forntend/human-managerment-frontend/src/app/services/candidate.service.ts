import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { Paging } from '../models/paging';
import { Candidate } from '../models/candidate';
import { ApiService } from './api.service';
import { HttpClient, HttpRequest, HttpHeaders, HttpEvent } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class CandidateService {

  constructor(private apiService: ApiService, private http: HttpClient) { }

  list(paging: Paging, type: number): Observable<RootObj<[Candidate]>> {
    const query = `page=${paging.page + 1}&page_limit=4`;
    console.log(`${this.apiService.apiUrl.candidates.home}/${type}?${query}`);
    return this.apiService.get<RootObj<[Candidate]>>
      (`${this.apiService.apiUrl.candidates.type}/${type}?${query}`);
  }

  getOne(id): Observable<RootObj<Candidate>> {
    return this.apiService.get<RootObj<Candidate>>
      (`${this.apiService.apiUrl.candidates.home}/${id}`);
  }

  edit(id, status: number): Observable<RootObj<Candidate>> {
    console.log("status: " + status);
    
    return this.apiService.put<RootObj<Candidate>>
      (`${this.apiService.apiUrl.candidates.home}/${id}`, status);
  }

  addCandidate(file: File, candidate: Candidate): Observable<any>{
    const formData: FormData = new FormData();
    formData.append('UploadedFile', file);
    formData.append('Firstname', candidate.firstname );
    formData.append('Lastname', candidate.lastname);
    formData.append('BirthDay', candidate.birthDay);
    formData.append('Gender', candidate.gender + '');
    formData.append('Email', candidate.email );
    formData.append('PhoneNumber', candidate.phoneNumber);
    formData.append('Ethnic', candidate.ethnic);
    formData.append('Hometown', candidate.hometown);
    formData.append('IDCard', candidate.IDCard);
    formData.append('Degree', candidate.degree);
    formData.append('Career', candidate.career);
    formData.append('Experience', candidate.experience);
    formData.append('Literacy', candidate.literacy);
    formData.append('Skill', candidate.skill);
    formData.append('Hobby', candidate.hobby);
    formData.append('Position', candidate.position);
    formData.append('Status', 0 + '');
    // formData.append('Note', candidate.note.id + '');
   // formData.append('Note',0 + '');
    formData.append('ImageName', '');
    formData.append('id', '');


    const req = new HttpRequest('POST', this.apiService.apiUrl.candidates.home, formData);

    return this.http.request(req);


  }
}
