import { Injectable } from "@angular/core"
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, of } from 'rxjs';

import { map } from 'rxjs/operators';
import{Comment} from '../model/comment.model';

@Injectable()
export class CommentService{

    constructor (private http: Http){

    }

    getData(): Observable<any> {

        return this.http.get("http://localhost:54042/api/comments").pipe(
            map((res) => this.extractData));           
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || [];
    }

    create(data: Comment): Promise<Comment> {
        const headers: Headers = new Headers();
     
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');
    return this.http
      .post("http://localhost:54042/api/comments", JSON.stringify(data), {headers: headers})
      .toPromise()
      .then(res => res.json().data as Comment);
  }


  update(hero: any): Promise<Comment> {
      const headers: Headers = new Headers();
     
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');
    const url = `http://localhost:54042/api/comments/${hero.Id}`;
    return this.http
      .put(url, JSON.stringify(hero), {headers: headers})
      .toPromise()
      .then(() => hero);
  }

 delete(hero: any): Promise<any> {
     const headers: Headers = new Headers();
     
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');
    const url = `http://localhost:54042/api/comments/${hero.Id}`;
    return this.http
      .delete(url, {headers: headers})
      .toPromise()
      .then(() => hero);
  }
}