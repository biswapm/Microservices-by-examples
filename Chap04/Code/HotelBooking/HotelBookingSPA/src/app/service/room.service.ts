import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RoomService {

  private accessPointUrl: string = 'https://localhost:44347/api';

  constructor(private http: HttpClient) { 
    
  }

  getHotelRooms(id: number) {  
    return this.http.get(this.accessPointUrl + "/rooms/getroomsbyhotel/" + id );
  } 

  addRoom(room: any)
  {
    return this.http.post(this.accessPointUrl + "/rooms", room);
  }

}
