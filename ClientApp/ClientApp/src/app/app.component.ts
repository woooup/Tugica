import { Component, OnInit, ElementRef } from '@angular/core';
import { AuthorizationService } from './service/authorization.service';
import {NgForm} from '@angular/forms';
import { BAIdentityUser} from './model/baidentityuser.model';
import { Router, ActivatedRoute } from '@angular/router';
import { Inject }  from '@angular/core';
import { DOCUMENT } from '@angular/common'; 

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit  {
  title = 'app';
  
  model: any = {};
  loading = false;
  returnUrl: string;
  public token: string;
  constructor( private route: ActivatedRoute,
    private router: Router,
    private authService: AuthorizationService,
    @Inject(DOCUMENT) document) {
  }

  ngOnInit() {

    this.router.navigate(['home']);

  }

  onSubmit(user : BAIdentityUser, form: NgForm) {
  
   
    let isLogg= this.authService.login(user);
      this.router.navigate(['/home']);
        console.log(user);
        var element = document.getElementById("Close") as any;
       
     
}
  isLoggedIn(): boolean{
        return this.authService.isLoggedIn();
  }

  isLoggedOut(): boolean{
    if(this.authService.isLoggedIn())
      return false;
    else
      return true;
}

  getUserRole(): any{
    // let user = JSON.parse(localStorage.getItem("currentUser"));
    // console.log("Rola je: " + user.role);
    // return user.role;
    return this.authService.getUserRole();
  }
  getUserName(): any{
    let user = JSON.parse(localStorage.getItem("currentUser"));
    return user.username;
  }

  logout(): void {
        this.authService.logout();
    }
}
