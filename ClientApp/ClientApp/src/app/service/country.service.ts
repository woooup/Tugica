import { Injectable } from "@angular/core"
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Observable, of } from 'rxjs';
import { Country} from '../model/country.model';
import { map } from 'rxjs/operators';


@Injectable()
export class CountryService{

    constructor (private http: Http){

    }

  create(data: Country): Promise<any> {
      const headers: Headers = new Headers();
     
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');
    return this.http
      .post("http://localhost:54042/api/countries", JSON.stringify(data), {headers: headers})
      .toPromise()
      .then(res => res.json().data as Country);
  }

 update(hero: any): Promise<Country> {
     const headers: Headers = new Headers();
     
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');
    const url = `http://localhost:54042/api/countries/${hero.Id}`;
    return this.http
      .put(url, JSON.stringify(hero), {headers: headers})
      .toPromise()
      .then(() => hero);
  }

    deleteCountry(country: number): Promise<any> {
        const headers: Headers = new Headers();
        
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');

        const opts: RequestOptions = new RequestOptions();
        opts.headers = headers;
        
        return this.http.delete("http://localhost:54042/api/countries" + '/' + country, opts).toPromise().
            then(response => {response.json(); alert("Successfully Deleted Country"); console.log(response.json())})
            ;
}
  getData(): Observable<any> {

        return this.http.get("http://localhost:54042/api/countries").pipe(
            map((res) => this.extractData));     
    }

     getCountry(id:any): Observable<any> {

        return this.http.get("http://localhost:54042/api/countries"+'/'+ id).pipe(
            map((res) => this.extractData));        
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || [];
    }





}




   
