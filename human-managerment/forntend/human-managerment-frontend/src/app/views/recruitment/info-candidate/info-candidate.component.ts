import { Component, OnInit, ViewChild } from '@angular/core';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CandidateService } from './../../../services/candidate.service';
import { NoteService } from './../../../services/note.service';
import { ApiService } from './../../../services/api.service';
import { Candidate } from '../../../models/candidate';
import { ActivatedRoute, Router } from '@angular/router';
import { Note } from '../../../models/note';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { MailForm } from './../../../models/mail-form';
import { MailService } from './../../../services/mail.service';
import { ScheduleService } from './../../../services/schedule.service';
import { Schedule } from './../../../models/schedule';

@Component({
  selector: 'app-info-candidate',
  templateUrl: './info-candidate.component.html',
  styleUrls: ['./info-candidate.component.css']
})
export class InfoCandidateComponent implements OnInit {
  @ViewChild('staticTabs', { static: false }) staticTabs: TabsetComponent;
  @ViewChild('addModal', { static: false }) addModal: ModalDirective;

  saveForm: FormGroup;
  candidate: Candidate;
  note: Note;
  empImgPath: any = this.apiService.apiUrl.employees.canimg;
  mailForm: MailForm = { title: 'Thư mời phỏng vấn'} as MailForm;
  mes: string;
  position: string;
  check = false;
  schedule: Schedule = {id: 0} as Schedule;
  constructor(private candidateService: CandidateService, private noteService: NoteService, private route: ActivatedRoute,
              private apiService: ApiService, private fb: FormBuilder, private mailService: MailService,
              private scheduleService: ScheduleService) {
                this.saveForm = this.fb.group({
                  date: [''],
                  time: [''],
                  title: [''],
                  position: [''],
                  content: [''],
                  });
               }

  ngOnInit(): void {
    const canID: number = Number(this.route.snapshot.paramMap.get('id'));
    this.candidateService.getOne(canID).subscribe(res => {
      console.log(res);
      this.candidate = res.data;
      this.mes = this.candidate.firstname + ' thân mến,\nTrước hết, chúng tôi rất cám ơn sự quan tâm bạn đã dành cho công ty của chúng tôi.\nQua hồ sơ của bạn, chúng tôi nhận thấy bạn có những tiềm năng để trở thành một phần của công ty chúng tôi.\nChúng tôi rất hy vọng có thể trao đổi thêm với bạn trong một buổi phỏng vấn ngắn tại ' + this.position + ' vào lúc ' + this.schedule.interviewDate + '. Đây là một bước cần thiết trong quá trình tuyển dụng để chúng tôi có thể hiểu hơn về bạn cũng như được chia sẻ với bạn nhiều hơn về câu chuyện của chúng tôi.\nChúng tôi rất mong sớm được gặp và trò chuyện với bạn.\nTrân trọng,';
    });
    this.noteService.getNote(canID).subscribe(res => {
      this.note = res.data;
      console.log(this.note);
    });
    console.log(this.mailForm);

  }

  change(e) {
    this.mes = this.candidate.firstname + ' thân mến,\nTrước hết, chúng tôi rất cám ơn sự quan tâm bạn đã dành cho công ty của chúng tôi.\nQua hồ sơ của bạn, chúng tôi nhận thấy bạn có những tiềm năng để trở thành một phần của công ty chúng tôi.\nChúng tôi rất hy vọng có thể trao đổi thêm với bạn trong một buổi phỏng vấn ngắn tại ' + this.position + ' vào lúc ' + this.schedule.interviewDate + '. Đây là một bước cần thiết trong quá trình tuyển dụng để chúng tôi có thể hiểu hơn về bạn cũng như được chia sẻ với bạn nhiều hơn về câu chuyện của chúng tôi.\nChúng tôi rất mong sớm được gặp và trò chuyện với bạn.\nTrân trọng,';
  }


  noteType(event) {
   this.note.content = event.target.value;
   setTimeout(() => {
    this.noteService.editNote(this.note.id, this.note).subscribe(res => {
      this.note = res.data;
    });
   }, 2000);
  }

  selectTab(tabId: number) {
    this.staticTabs.tabs[tabId].active = true;
  }

  showAddModal() {
    this.addModal.show();
  }

  hideModal() {
    this.addModal.hide();
  }

  toggleVisibility(e){
    this.check = e.target.checked;
  }

  create() {
    this.mailForm.address = this.candidate.email;
    this.mailForm.content = this.mes;
    this.schedule.canId = this.candidate.id;
    this.schedule.canName = this.candidate.lastname;
    console.log(this.schedule);
    this.scheduleService.save(this.schedule).subscribe(res => {
      console.log(res);
    });
    if (this.check) {
    this.mailService.send(this.mailForm).subscribe(res => {
      console.log(res);
    });
  }
  this.hideModal();
  }
}
