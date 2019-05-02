import { Component, OnInit } from '@angular/core';
import { HotelService } from '../service/hotel.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private hotelService: HotelService) { }

  fromDate: string;
  
  hotelList: any[];

  ngOnInit() {
    this.loadHotels();
  }

  loadHotels()
  {
    this.hotelService.getHotels().subscribe(
      (hotels: any)=>{
          if (hotels) {
            this.hotelList = hotels;
            //console.log(this.hotelList);
          }
      },
      (err: HttpErrorResponse)=>{}
    )
  }

}
