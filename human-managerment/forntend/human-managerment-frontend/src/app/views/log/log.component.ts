import { Component, OnInit, ViewChild } from '@angular/core';
import { Paging } from '../../models/paging';
import { LogService } from './../../services/log.service';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Log } from '../../models/log';

@Component({
  selector: 'app-log',
  templateUrl: './log.component.html',
  styleUrls: ['./log.component.css']
})
export class LogComponent implements OnInit {
  paging = { page: 0, pageLimit: 10, totalItems: 3 } as Paging;
  logs = [];
  constructor(private logService: LogService) { }

  ngOnInit(): void {
    this.loadLog();
  }
  loadLog(page = null){
    if (page != null) {
      this.paging.page = page.offset;
    }
    this.logService.listLog(this.paging).subscribe(res => {
      console.log(res);
      this.logs = res.data;
      this.paging = res.paging;
    });

  };
}
