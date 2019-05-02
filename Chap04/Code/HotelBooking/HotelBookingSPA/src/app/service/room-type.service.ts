import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RoomTypeService {

  private accessPointUrl: string = 'https://localhost:44347/api';

  constructor(private http: HttpClient) { }

  getRoomTypes() {  
    return this.http.get(this.accessPointUrl + "/RoomTypes" );
  } 

}
