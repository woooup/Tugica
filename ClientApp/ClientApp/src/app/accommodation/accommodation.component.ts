import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { AccommodationService } from '../service/accommodation.service';
import { Accommodation } from '../model/accommodation.model';
import { AccommodationType } from '../model/accommodation-type.model';
import { AuthorizationService } from '../service/authorization.service';
import { Place } from '../model/place.model';
import { AccommodationTypeService } from '../service/accommodation-type.service';
import {PlaceService} from '../service/place.service';
import {NgForm} from '@angular/forms';
@Component({
  selector: 'app-accommodation',
  templateUrl: './accommodation.component.html',
  styleUrls: ['./accommodation.component.css']
})
export class AccommodationComponent implements OnInit {

  @Input() accommodation: Accommodation[];
  @Input() accommodationTypes: AccommodationType[];
  @Input() places: Place[];
  sub: any;
  accommodationId: string;

  constructor(private route: ActivatedRoute, private accommodationService: AccommodationService,private placeService: PlaceService,private accommodationTypeService: AccommodationTypeService, private authService: AuthorizationService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.accommodationId = params['id'];
    });

    this.placeService.getData().subscribe(
      (prod: any) => { this.places = prod; console.log(this.places) },//You can set the type to Product.
      error => { alert("Unsuccessful fetch operation!"); console.log(error); });


    this.accommodationTypeService.getData().subscribe(
      (prod: any) => { this.accommodationTypes = prod; console.log(this.accommodationTypes) },//You can set the type to Product.
      error => { alert("Unsuccessful fetch operation!"); console.log(error); });


    this.accommodationService.getData().subscribe(
      (prod: any) => { this.accommodation = prod; console.log(this.accommodation) },//You can set the type to Product.
      error => { alert("Unsuccessful fetch operation!"); console.log(error); });

  }

  onSubmit(user : Accommodation, form: NgForm) {

  
    var e = (document.getElementById("comboboxAccType")) as HTMLSelectElement;
    var sel = e.selectedIndex as number;
    user.AccomodationType=this.accommodationTypes[sel];

    var es = (document.getElementById("PlaceSelect")) as HTMLSelectElement;
    var sels = es.selectedIndex as number;
    user.Place=this.places[sels];


   // user.AccomodationType=
    this.accommodationService.postAccommodation(user);
    
     
}

}
