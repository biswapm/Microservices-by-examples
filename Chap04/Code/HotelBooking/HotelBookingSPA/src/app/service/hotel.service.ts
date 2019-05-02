import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class HotelService {
  //private headers: HttpHeaders;
  private accessPointUrl: string = 'https://localhost:44347/api';

  constructor(private http: HttpClient) {
    //this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getHotels() {  
    return this.http.get(this.accessPointUrl + "/hotelsinfo/hotelslist");
  }  
  
  getHotelInfo(id: number) {  
    return this.http.get(this.accessPointUrl + "/hotelsinfo/" + id );
  }  
 
  addHotel(hotel: any)
  {
    return this.http.post(this.accessPointUrl + "/hotelsinfo", hotel);
  }
}