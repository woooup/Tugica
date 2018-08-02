import { Injectable } from "@angular/core"
import { Http,Response, RequestOptions, Headers } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import {Accommodation} from '../model/accommodation.model';
import { AccommodationType } from "../model/accommodation-type.model";
import { Room } from "../model/room.model";
import { Comment } from "../model/comment.model";
@Injectable()

export class AccommodationService{
    data: Accommodation[];
    private headers = new HttpHeaders({'Content-Type': 'application/json'});
    constructor (private http:HttpClient){

    }

    getData():  Observable<Accommodation[]> {
        return this.http.get<Accommodation[]>("http://localhost:54042/api/accommodations");
        
    }

    getAccommodations(): Promise<Accommodation[]> {
        return this.http.get("http://localhost:54042/api/Accommodations")
                    .toPromise()
                    .then(response => response as Accommodation[]);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || [];
    }
    getAccomodation(id:any): Observable<Accommodation> {

        return this.http.get("http://localhost:54042/api/accommodations"+'/'+ id).pipe(map((response: any) => response));       
    } 

    postAccomodation(data: Accommodation): Promise<any> {

        const headers: HttpHeaders = new HttpHeaders();
     
        if(localStorage.getItem("token") !== null)
        {
            headers.append("Authorization", localStorage.getItem("token"));
        }
        headers.append('Accept', 'application/json');
        headers.append('Content-type', 'application/json');


  
      return this.http
        .post("http://localhost:54042/api/accommodations", JSON.stringify(data), {headers: headers})
        .toPromise()
        .then(res => res);
    }

    postAccommodation(accommodation: any): Promise<any> {
        //this.headers.append("Accept", "text/plain")
        return this.http
            .post('http://localhost:54042/api/Accommodations', 
            JSON.stringify({
                Name: accommodation.Name,
                Address: accommodation.Address,
                Description: accommodation.Description,
                Latitude: accommodation.Latitude,
                Longitude: accommodation.Longitude,
                ImageURL: accommodation.ImageURL,
                User: {
                    Name:"mitja"
                },
                Rooms:Array<Room>(),
                AccomodationType: accommodation.AccomodationType,
                Place: accommodation.Place,
                Comments:Array<Comment>()
            
        }),
             {headers: this.headers})
            .toPromise()
            .then(res => res as Accommodation)
            .catch(this.handleError);
    }   
    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }

}