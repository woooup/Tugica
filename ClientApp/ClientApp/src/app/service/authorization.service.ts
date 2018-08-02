import { BAIdentityUser} from '../model/baidentityuser.model';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Injectable } from "@angular/core";
import { Observable, of } from 'rxjs';
import {Router} from '@angular/router';

@Injectable()
export class AuthorizationService {
    
    public token: string;
    public isLogg:boolean
    private headers = new Headers();
        
    constructor(private http: Http, public router:Router) {
        // set token if saved in local storage
        var currentUser = JSON.parse(localStorage.getItem('currentUser'));
        if(currentUser != null)
        {
            this.token = currentUser.token;
        }
    }

    login(user:BAIdentityUser){

        let hd = new Headers();
        hd.append('Content-Type', 'application/x-www-form-urlencoded');
       
        let options = new RequestOptions();
        options.headers = hd;

        let x =this.http.post('http://localhost:54042/oauth/token', `username=${user.Username}&password=${user.Password}&grant_type=password`, options)
            .subscribe((response: Response) => {
                    let token = response.json().access_token;
                    if (token) {
                        // set token property
                        this.token = token;

                        //set user role
                        var role = response.headers.get('role');
                        console.log(role);
                        // store username and jwt token in local storage to keep user logged in between page refreshes
                        localStorage.setItem('currentUser', JSON.stringify({ username: user.Username, token: token, role : role }));
                        // return true to indicate successful login
                        
                        return true;
                    
                    } else {
                        // return false to indicate failed login
               
                        return false;
                      
                    }
                }
            );
   
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

    getUserRole(): any{
        let user = JSON.parse(localStorage.getItem("currentUser"));
        console.log("Rola je: " + user.role);
        return user.role;
  }
    getUserName(): any{
        let user = JSON.parse(localStorage.getItem("currentUser"));
        return user.username;
  }
}