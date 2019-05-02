import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

// services
import { HotelService } from './service/hotel.service';
import { RoomTypeService } from './service/room-type.service';
// services

// components
import { AppComponent } from './app.component';

import { HomeComponent } from './home/home.component';
import { HotelsComponent } from './home/hotels/hotels.component';
import { HotelComponent } from './home/hotels/hotel/hotel.component';
import { RoomsComponent } from './home/hotels/hotel/rooms/rooms.component';
import { BookingsComponent } from './home/bookings/bookings.component';
import { CheckoutComponent } from './home/checkout/checkout.component';
import { ReviewsComponent } from './home/reviews/reviews.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { AddorupdatehotelComponent } from './admin/Hotel/addorupdatehotel/addorupdatehotel.component';
import { RoomComponent } from './admin/Hotel/room/room.component';
import { AddorupdateroomtypeComponent } from './admin/Hotel/room/addorupdateroomtype/addorupdateroomtype.component';
import { AddorupdateroomComponent } from './admin/Hotel/room/addorupdateroom/addorupdateroom.component';
import { FacilitiesComponent } from './admin/Hotel/room/facilities/facilities.component';
import { AddorupdatefacilitiesComponent } from './admin/Hotel/room/facilities/addorupdatefacilities/addorupdatefacilities.component';
import { FacilitiesListComponent } from './admin/Hotel/room/facilities/facilities-list/facilities-list.component';
import { RoomsListComponent } from './admin/Hotel/room/rooms-list/rooms-list.component';
import { HotelDetailComponent } from './admin/hotel/hotel-detail/hotel-detail.component';
//components

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'admin/hotel/add', component: HotelDetailComponent },
  { path: 'admin/hotel/edit/:id', component: HotelDetailComponent },
  { path: 'admin/hotel/room/:hotelId', component: RoomComponent },
  //{ path: 'hotels/hotel', component: HotelComponent },
  { path: 'hotels/hotel', component: HotelComponent },
  { path: 'hotels/hotel/:id', component: HotelComponent },
  { path: 'login', component: LoginComponent }
];


@NgModule({
  declarations: [
    AppComponent,
    AdminComponent,
    HomeComponent,
    HotelsComponent,
    HotelComponent,
    RoomsComponent,
    BookingsComponent,
    CheckoutComponent,
    ReviewsComponent,
    AddorupdatehotelComponent,
    RoomComponent,
    AddorupdateroomtypeComponent,
    AddorupdateroomComponent,
    FacilitiesComponent,
    AddorupdatefacilitiesComponent,
    FacilitiesListComponent,
    RoomsListComponent,
    LoginComponent,
    HotelDetailComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    HotelService, 
    RoomTypeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
