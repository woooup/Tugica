import { Injectable } from "@angular/core"
import { Http,Response, RequestOptions, Headers } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import {Accommodation} from '../model/accommodation.model';
import { AccommodationType } from "../model/accommodation-type.model";
@Injectable()

export class AccommodationTypeService{
    data: AccommodationType[];
    
    constructor (private http:HttpClient){

    }

    getData():  Observable<AccommodationType[]> {
        return this.http.get<AccommodationType[]>("http://localhost:54042/api/accommodationtypes");
        
    }

    getAccommodations(): Promise<AccommodationType[]> {
        return this.http.get("http://localhost:54042/api/accommodationtypes")
                    .toPromise()
                    .then(response => response as Accommodation[]);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || [];
    }
    getAccomodation(id:any): Observable<AccommodationType> {

        return this.http.get("http://localhost:54042/api/accommodationtypes"+'/'+ id).pipe(map((response: any) => response));       
    } 



}
