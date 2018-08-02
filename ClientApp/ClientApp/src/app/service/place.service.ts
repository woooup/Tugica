import { Injectable } from "@angular/core"
import { Http,Response, RequestOptions, Headers } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import {Place} from '../model/place.model';
@Injectable()

export class PlaceService{
    data: Place[];
    
    constructor (private http:HttpClient){

    }

    getData():  Observable<Place[]> {
        return this.http.get<Place[]>("http://localhost:54042/api/places");
        
    }

    getPlaces(): Promise<Place[]> {
        return this.http.get("http://localhost:54042/api/places")
                    .toPromise()
                    .then(response => response as Place[]);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || [];
    }
    getPlace(id:any): Observable<Place> {

        return this.http.get("http://localhost:54042/api/places"+'/'+ id).pipe(map((response: any) => response));       
    } 



}