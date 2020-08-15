import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RootObj } from '../models/root-obj';
import { Paging } from '../models/paging';
import { Note } from '../models/note';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class NoteService {

  constructor(private apiService: ApiService) { }

  editNote(id, note: Note): Observable<RootObj<Note>> {
    return this.apiService.put<RootObj<Note>>
      (`${this.apiService.apiUrl.notes.home}/${id}`, note);
  }

  getNote(id): Observable<RootObj<Note>> {
    return this.apiService.get<RootObj<Note>>
      (`${this.apiService.apiUrl.notes.home}/${id}`);
  }
}
