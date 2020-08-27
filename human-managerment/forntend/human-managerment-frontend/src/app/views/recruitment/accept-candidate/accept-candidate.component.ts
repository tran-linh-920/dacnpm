import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Paging } from '../../../models/paging';
import { Subscription } from 'rxjs';
import { Candidate } from '../../../models/candidate';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from './../../../services/candidate.service';
import { ApiService } from './../../../services/api.service';
import { Employee } from '../../../models/employee';
import { MailForm } from '../../../models/mail-form';
import { MailService } from '../../../services/mail.service';
import { EmployeeService } from './../../../services/employee.service';
import { ToastrService } from 'ngx-toastr';
import { Job } from '../../../models/job';



@Component({
  selector: 'app-accept-candidate',
  templateUrl: './accept-candidate.component.html',
  styleUrls: ['./accept-candidate.component.css']
})
export class AcceptCandidateComponent implements OnInit {
  @ViewChild('salaryModal', { static: false }) salaryModal: ModalDirective;

  salaryForm: FormGroup;
  salary: number;
  candidates: Candidate[];
  mailForm: MailForm = {title: 'Thư mời nhận việc'} as MailForm;
  chosenCandidate: Candidate = {id: 0} as Candidate;
  chosenEmployee: Employee = {id: 0} as Employee;
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  empImgPath: any = this.apiService.apiUrl.employees.canimg;
  position: string;
  date: Date;
  mes: string;
  jobs: Job[];
  emJob: Job;
  constructor(private candidateService: CandidateService, private fb: FormBuilder, private router: Router, private apiService: ApiService,
              private mailService: MailService, private employeeService: EmployeeService, private toast: ToastrService) 
              {
                this.salaryForm = this.fb.group({
                  salary: [''],
                  title: [''],
                  content: [''],
                  position: [''],
                  date: [''],
                  mes: [''],
                  });
               }

  ngOnInit(): void {
    this.loadCandidate(null);
    this.candidateService.getJob().subscribe(res => {
      this.jobs = res.data;
    });
  }

  loadCandidate(page = null) {
    // if (page != null) {
    //   this.paging.page = page.offset;
    // }
    this.candidateService.list(this.paging, 1).subscribe(res => {
      console.log(res);
      this.candidates = res.data;
     // this.paging = res.paging;
    });
  };

  decline(id) {
    this.candidateService.edit(id, 3).subscribe(res => {
      this.loadCandidate(null);
    });
  }

  change(e) {
    this.mes = 'Kính gửi: Anh/Chị ' + this.chosenCandidate.firstname + ',\nChúng tôi chân thành cảm ơn sự quan tâm của Anh/Chị đối với công ty cũng như chức danh công việc mà Anh/Chị đã dự tuyển. Chúng tôi trân trọng thông báo Anh/Chị đã trúng tuyển trong đợt phỏng vấn vừa qua. Anh/Chị sẽ:\n- Làm việc tại: ' + this.position + '\n- Chức danh công việc: ' + this.chosenCandidate.position + '\n- Thời gian: ' + this.date + '\nLương và các chế độ khác như sau:\n- Lương: ' + this.salary + '\n- Các chế độ khác: Theo Luật Lao động Việt Nam, theo Nội quy lao động và Quy định'
    this.mes += ' tài chính của công ty.\nChúng tôi hoan nghênh sự gia nhập của Anh/Chị vào công ty và hy vọng chúng ta sẽ có một sự hợp tác tốt đẹp, lâu bền.\nTrân trọng';
  }

  openModal(candidate: Candidate) {
    this.chosenCandidate = candidate;
    this.mes = 'Kính gửi: Anh/Chị ' + this.chosenCandidate.firstname + ',\nChúng tôi chân thành cảm ơn sự quan tâm của Anh/Chị đối với công ty cũng như chức danh công việc mà Anh/Chị đã dự tuyển. Chúng tôi trân trọng thông báo Anh/Chị đã trúng tuyển trong đợt phỏng vấn vừa qua. Anh/Chị sẽ:\n- Làm việc tại: ' + this.position + '\n- Chức danh công việc: ' + this.chosenCandidate.position + '\n- Thời gian: ' + this.date + '\nLương và các chế độ khác như sau:\n- Lương: ' + this.salary + '\n- Các chế độ khác: Theo Luật Lao động Việt Nam, theo Nội quy lao động và Quy định'
    this.mes += ' tài chính của công ty.\nChúng tôi hoan nghênh sự gia nhập của Anh/Chị vào công ty và hy vọng chúng ta sẽ có một sự hợp tác tốt đẹp, lâu bền.\nTrân trọng';
    this.salaryModal.show();
  }

  hideModal() {
    this.salaryModal.hide();
  }

  accept() {
    this.jobs.forEach(element => {
      if(element.jobTitle == this.chosenCandidate.position) {
        this.emJob = element;
        }
    });
    this.mailForm.address = this.chosenCandidate.email;
    this.mailForm.content = this.mes;
    this.chosenEmployee = {birthDay: this.chosenCandidate.birthDay, email: this.chosenCandidate.email,
                           firstname: this.chosenCandidate.firstname, id: 0,
                            gender: this.chosenCandidate.gender, jobLevel: 1, hireDay: this.chosenCandidate.birthDay,
                            imageName: this.chosenCandidate.imageName, phoneNumber: this.chosenCandidate.phoneNumber,
                            lastname: this.chosenCandidate.lastname, job: this.emJob }
    console.log(this.chosenEmployee);
    
    this.employeeService.OfficialEmployee(this.chosenEmployee).subscribe(res => {
      console.log(res);
      this.candidateService.edit(this.chosenCandidate.id, 4).subscribe(res => {
        this.loadCandidate(null);
      });
    });
    this.mailService.send(this.mailForm).subscribe(res => {
      console.log(res);
    });
    this.toast.success('Thông báo', 'Thành công');
    this.hideModal();
  }
}
