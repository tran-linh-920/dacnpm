import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../../../services/api.service';
import { DepartmentService } from '../../../services/department.service';
import { Paging } from '../../../models/paging';
import { Department } from '../../../models/department';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ModalDirective } from 'ngx-bootstrap/modal';


@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {
  @ViewChild('depModal', { static: false }) depModal: ModalDirective;
  isCollapsed = false;
  department = {id: 0} as Department;
  departments = [];
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  panelOpenState = false;
  saveForm: FormGroup;

  constructor( private departmentService: DepartmentService,
    private apiService: ApiService,  private fb: FormBuilder) { 
      this.saveForm = this.fb.group({
        name: [''],
        bio: [''],
      });
    }

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(page = null) {
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.departmentService.list(this.paging).subscribe(res => {
      this.departments = res.data;
      this.paging = res.paging;
    });
  };

  openModal() {
    this.depModal.show();
  }

  hideModal() {
    this.depModal.hide();
  }
  save() {
    this.departmentService.addDepart(this.department).subscribe(res => {
      console.log(res);
      this.depModal.hide();
      this.loadDepartments();
    });
  }
}
