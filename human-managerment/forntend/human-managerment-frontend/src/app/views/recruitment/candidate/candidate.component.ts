import { Component, OnInit, ViewChild, OnDestroy,  } from '@angular/core';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { Paging } from '../../../models/paging';
import { Subscription } from 'rxjs';
import { Candidate } from '../../../models/candidate';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidateService } from './../../../services/candidate.service';
import { ApiService } from './../../../services/api.service';

@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.css']
})
export class CandidateComponent implements OnInit{
  @ViewChild('staticTabs', { static: false }) staticTabs: TabsetComponent;
  candidates: Candidate[];
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  empImgPath: any = this.apiService.apiUrl.employees.canimg;

  constructor(private candidateService: CandidateService, private router: Router, private apiService: ApiService) { }
 

  ngOnInit(): void {
   this.loadCandidate(null);
  }
 
  selectTab(tabId: number) {
    this.staticTabs.tabs[tabId].active = true;
  }

  loadCandidate(page = null) {
    // if (page != null) {
    //   this.paging.page = page.offset;
    // }
    this.candidateService.list(this.paging, 0).subscribe(res => {
      console.log(res);
      this.candidates = res.data;
     // this.paging = res.paging;
    });
  };

  choose(id){
    this.router.navigateByUrl(`tuyen-dung/info/${id}`);
  }

  accept(id) {
    this.candidateService.edit(id, 1).subscribe(res => {
      this.loadCandidate(null);
    });
  }

  decline(id) {
    this.candidateService.edit(id, 3).subscribe(res => {
      this.ngOnInit();
    });
  }
 
  toAdd() {
    // console.log("dsadsadsa");
     this.router.navigate(['tuyen-dung/add']);
  }

  toSchedule() {
    this.router.navigate(['tuyen-dung/schedule']);
  }

}
