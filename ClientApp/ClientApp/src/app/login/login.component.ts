import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from '../service/authorization.service';
import {NgForm} from '@angular/forms';
import { BAIdentityUser} from '../model/baidentityuser.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  loading = false;
  returnUrl: string;
  public token: string;

  constructor(
      private route: ActivatedRoute,
      private router: Router,
      private authService: AuthorizationService) { }

  ngOnInit() {
      // reset login status
     // this.authService.logout();

      // get return url from route parameters or default to '/'
      //this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  onSubmit(user : BAIdentityUser, form: NgForm) {
      this.loading = true;
      this.authService.login(user);
        this.router.navigate(['/home']);
          console.log(user);
          this.router.navigate(['../home']);
       
  }

  logout(): void {
      // clear token remove user from local storage to log user out
      this.token = null;
      localStorage.removeItem('currentUser');
  }

  isLoggedIn(): boolean{
      if (localStorage.getItem('currentUser') === null){
          return false;
      }
      else{
          return true;
      }
  }

  getUserName(): any{
  let user = JSON.parse(localStorage.getItem("currentUser"));
  return user.username;
  }
}