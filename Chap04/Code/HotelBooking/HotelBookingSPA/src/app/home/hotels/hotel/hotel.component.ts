import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router'
import { HotelService } from '../../../service/hotel.service';
import { HttpErrorResponse } from '@angular/common/http';
import { RoomService } from '../../../service/room.service';

@Component({
  selector: 'app-hotel',
  templateUrl: './hotel.component.html',
  styleUrls: ['./hotel.component.css']
})
export class HotelComponent implements OnInit {

  hotelId : number;
  hotelName: string;
  hotelAddress: string;
  description: string;
  hotelRooms: any[];

  constructor(private router: Router, private route: ActivatedRoute, private hotelService: HotelService, private roomService: RoomService) { 
    this.route.params.subscribe(res => {
      this.hotelId = res.id;

      this.hotelService.getHotelInfo(this.hotelId).subscribe(
        (response: any)=>{
          if (response) {
            this.hotelName = response.hotelName;
            this.description = response.description;
          }

          this.roomService.getHotelRooms(this.hotelId).subscribe(
            (response: any)=>{
              if (response) {
                this.hotelRooms = response;
              }
            },
            (err: HttpErrorResponse)=>{}
          )
        },
        (err: HttpErrorResponse)=>{}
      )
    });
  }
  ngOnInit() {}
}
