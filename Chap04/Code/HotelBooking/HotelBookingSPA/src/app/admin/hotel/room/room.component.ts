import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { RoomTypeService } from '../../../service/room-type.service';
import { RoomService } from '../../../service/room.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-room',
  templateUrl: './room.component.html',
  styleUrls: ['./room.component.css']
})
export class RoomComponent implements OnInit {

  hotelId: number;
  roomId: number;
  roomNumber: number;
  noOfGuest: number;
  roomRent: number;
  description: string;
  roomType: number = 0;

  roomTypes: any[];
  hotelRooms: any[];

  constructor(private route: ActivatedRoute, private roomTypeService: RoomTypeService, private roomService: RoomService) { 
    this.route.params.subscribe(res => {
      this.hotelId = res.hotelId;
      this.loadRooms();
    });
  }

  ngOnInit() {
    this.loadRoomTypes()
  }

  loadRooms()
  {
    this.roomService.getHotelRooms(this.hotelId).subscribe(
      (response: any)=>{
        if (response) {
          this.hotelRooms = response;
        }
      },
      (err: HttpErrorResponse)=>{}
    )
  }

  loadRoomTypes()
  {
    this.roomTypeService.getRoomTypes().subscribe(
      (roomTypes: any)=>{
          if (roomTypes) {
            this.roomTypes = roomTypes;
          }
      },
      (err: HttpErrorResponse)=>{}
    )
  }

  submit()
  {
    var room: any = {
      HotelID: this.hotelId,
      Number: this.roomNumber,
      Description : this.description,
      MaximumGuests: this.noOfGuest,
      Price: this.roomRent,
      RoomTypeID: this.roomType,
      Available: 1
    }

    this.roomService.addRoom(room).subscribe(
      (response: any)=>{
          if (response) {
            this.loadRooms();
          }
      },
      (err: HttpErrorResponse)=>{}
    )
  }

  loadRoom(room: any)
  {
    this.roomId = room.id;
    this.roomNumber = room.number;
    this.noOfGuest = room.maximumGuests;
    this.roomRent = room.price;
    this.description = room.description;
    this.roomType = room.roomTypeId;
  }
}
