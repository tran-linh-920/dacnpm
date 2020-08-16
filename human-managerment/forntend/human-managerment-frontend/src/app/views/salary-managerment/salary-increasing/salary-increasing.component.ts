import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { Employee } from '../../../models/employee';
import { Paging } from '../../../models/paging';
import { EmployeeService } from '../../../services/employee.service';
import { ApiService } from '../../../services/api.service';
import { SalaryService } from '../../../services/salary.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-salary-increasing',
  templateUrl: './salary-increasing.component.html',
  styleUrls: ['./salary-increasing.component.css']
})
export class SalaryIncreasingComponent implements OnInit {

  employees: Employee[] = [];
  paging = { page: 1, pageLimit: 10, totalItems: 10 } as Paging;
  message = '';
  notifyModalRef: BsModalRef;
  @ViewChild('notifyModalTemplate') public notifyModalTemplate: TemplateRef<any>;

  constructor(private employeeService: EmployeeService, private salaryService: SalaryService, private apiService: ApiService, private modalService: BsModalService) { }

  ngOnInit(): void {
    this.loadEmpWithJobInfor();
  }

  loadEmpWithJobInfor(page = null) {
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.employeeService.jobInformations(this.paging).subscribe(res => {
      this.employees = res.data;
      this.paging = res.paging;
    });
  };

  increaseSalary(empId: number, jobLevel: number) {
    console.log('empId ' + empId);

    this.salaryService.increase(empId, jobLevel).subscribe(
      res => {
        this.loadEmpWithJobInfor();
      },
      err => {
        this.message = err.error.Message;
        this.notifyModalRef = this.modalService.show(this.notifyModalTemplate);
      });
  }

}
