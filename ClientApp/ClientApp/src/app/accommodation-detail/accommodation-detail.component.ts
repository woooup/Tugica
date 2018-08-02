import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { AccommodationService } from '../service/accommodation.service';
import { Accommodation } from '../model/accommodation.model';
import { AuthorizationService } from '../service/authorization.service';

@Component({
  selector: 'app-accommodation-detail',
  templateUrl: './accommodation-detail.component.html',
  styleUrls: ['./accommodation-detail.component.css']
})
export class AccommodationDetailComponent implements OnInit {
  @Input() accommodation: Accommodation;
  sub: any;
  accommodationId: string;

  constructor(private route: ActivatedRoute, private accommodationService: AccommodationService, private authService: AuthorizationService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.accommodationId = params['id'];
    });


    this.accommodationService.getAccomodation(this.accommodationId).subscribe(
      (prod: any) => { this.accommodation = prod; console.log(this.accommodation) },//You can set the type to Product.
      error => { alert("Unsuccessful fetch operation!"); console.log(error); });

  }
  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
  getUserRole(): any {
    return this.authService.getUserRole();
  }
}
