import { Component, OnInit } from '@angular/core';
import { SalaryService } from '../../../services/salary.service';
import { ApiService } from '../../../services/api.service';
import { Paging } from '../../../models/paging';
import { SalaryHistory } from '../../../models/salary-history';

@Component({
  selector: 'app-salary-counting',
  templateUrl: './salary-counting.component.html',
  styleUrls: ['./salary-counting.component.css']
})
export class SalaryCountingComponent implements OnInit {
  
  salaryHistories: SalaryHistory[] = [];
  paging = { page: 0, pageLimit: 10, totalItems: 10 } as Paging;

  constructor(
    private salaryService: SalaryService, private apiService: ApiService
  ) { }

  ngOnInit(): void {
    this.loadSalaryHistories();
  }
  
  loadSalaryHistories(page = null) {
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.salaryService.histories(this.paging).subscribe(res => {
      this.salaryHistories = res.data;
      this.paging = res.paging;
    });
   
  };

}
