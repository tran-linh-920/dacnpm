import {Component, OnInit} from '@angular/core';
import { navItems } from '../../_nav';
import { CookieService } from 'ngx-cookie-service';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent implements OnInit {
  public sidebarMinimized = false;
  public navItems = navItems;
  show = false;
  constructor(private cookieService: CookieService, private router: Router ) {}

  ngOnInit() {
  const token = this.cookieService.get('token');
  if (token) {
  this.show = true;
  } else {
  this.show = false;
  }
  }
  
  toggleMinimize(e) {
    this.sidebarMinimized = e;
  }
}
