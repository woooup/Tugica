import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule,JsonpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PlaceComponent } from './place/place.component';
import { RegionComponent } from './region/region.component';
import { RoomsComponent } from './rooms/rooms.component';
import { MapComponent } from './map/map.component';
import { CountryComponent } from './country/country.component';
import { LoginComponent } from './login/login.component';
import { CommentComponent } from './comment/comment.component';
import { AccommodationComponent } from './accommodation/accommodation.component';
import {AuthorizationService} from './service/authorization.service'
import { AccommodationService } from './service/accommodation.service';
import { PlaceService } from './service/place.service';
import { CommentService } from './service/comment.service';
import { CountryService } from './service/country.service';
import { AccommodationTypeService } from './service/accommodation-type.service';
import { HttpClient } from 'selenium-webdriver/http';
import { HttpClientModule } from '@angular/common/http'; 
import { Accommodation } from './model/accommodation.model';
import { AccommodationDetailComponent } from './accommodation-detail/accommodation-detail.component';
const Routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: HomeComponent },
  { path: 'accommodation', component: AccommodationComponent },
  { path: 'accommodation-detail/:id', component: AccommodationDetailComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PlaceComponent,
    RegionComponent,
    RoomsComponent,
    MapComponent,
    CountryComponent,
    LoginComponent,
    CommentComponent,
    AccommodationComponent,
    AccommodationDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    JsonpModule,
    RouterModule.forRoot(
      Routes),
  ],
  providers: [AuthorizationService,AccommodationService,PlaceService,CommentService,CountryService,AccommodationTypeService],
  bootstrap: [AppComponent]
})
export class AppModule { }
