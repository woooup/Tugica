import { Component, OnInit } from '@angular/core';
import { CountryService } from '../service/country.service';
import { Accommodation } from '../model/accommodation.model';
import { Region } from '../model/region.model';
import { NgForm } from '@angular/forms';
import { AccommodationService } from '../service/accommodation.service';
import { AuthorizationService } from '../service/authorization.service';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  data: Accommodation[];

  constructor(private _serviceR: AccommodationService, private router: Router, private authService: AuthorizationService
  ) { }

  ngOnInit() {

    this._serviceR.getAccommodations()
      .then(allAccommodations => { this.data = allAccommodations; console.log(this.data) });
  }
  isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  isLoggedOut(): boolean {
    if (this.authService.isLoggedIn())
      return false;
    else
      return true;
  }

  goToDetails() {
    var ownerElement = Number.parseInt((<HTMLInputElement>document.getElementById("accommodationName")).value);
    this.router.navigate(['/accommodation-detail', ownerElement]);
  }
  getUserRole(): any {
    // let user = JSON.parse(localStorage.getItem("currentUser"));
    // console.log("Rola je: " + user.role);
    // return user.role;
    return this.authService.getUserRole();
  }
}
