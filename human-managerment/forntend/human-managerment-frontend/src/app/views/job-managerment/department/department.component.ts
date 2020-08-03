import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiService } from '../../../services/api.service';
import { DepartmentService } from '../../../services/department.service';
import { Paging } from '../../../models/paging';

@Component({
  selector: 'app-department',
  templateUrl: './department.component.html',
  styleUrls: ['./department.component.css']
})
export class DepartmentComponent implements OnInit {

  isCollapsed = false;
  departments = [];
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;

  constructor( private departmentService: DepartmentService,
    private apiService: ApiService) { }

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


}
