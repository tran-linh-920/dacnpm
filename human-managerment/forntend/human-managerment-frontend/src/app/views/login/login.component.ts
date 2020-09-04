import { AuthService } from './../../services/auth.service';
import { Component, ViewChild, ElementRef, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent implements AfterViewInit {
  @ViewChild('userNameField', {static: false}) userNameField: ElementRef;
  message: string = '';
  userName: string;
  password: string;
  constructor(private userService: UserService, private authService: AuthService, private router: Router) {}
  ngAfterViewInit() {
    this.userNameField.nativeElement.focus();
  }
  login() {
    console.log(this.userName +" "+ this.password);
    this.userService.login(this.userName, this.password).subscribe( res => {
      console.log(res.data);
      if (res.statusCode === 200) {
        this.message = '';
        // save user info, then redirect to dashboard
        localStorage.setItem('userInfo', JSON.stringify(res.data));
        localStorage.setItem('token', res.data.token);
        this.authService.setLoggedIn(true);
        this.router.navigate(['/dashboard']);
      } else {
        this.message = res.message;
      }
    });
  }
}
