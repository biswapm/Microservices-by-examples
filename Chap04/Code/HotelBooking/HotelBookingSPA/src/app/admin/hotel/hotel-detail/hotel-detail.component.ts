import { Component, OnInit } from '@angular/core';
import { HotelService } from '../../../service/hotel.service';
import { ActivatedRoute, Router } from '@angular/router'
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-hotel-detail',
  templateUrl: './hotel-detail.component.html',
  styleUrls: ['./hotel-detail.component.css']
})
export class HotelDetailComponent implements OnInit {

  hotelId: number;
  hotelName: string = 'New Hotel';
  description: string;
  
  constructor(private route: ActivatedRoute, private router: Router, private hotelService: HotelService) { 
    this.route.params.subscribe(res => {
      if(res.id)
      {
        this.hotelId = res.id;
        this.loadHotel();
      }
    });
  }

  ngOnInit() {
  }

  loadHotel()
  {
    this.hotelService.getHotelInfo(this.hotelId).subscribe(
      (response: any)=>{
        if (response) {
          this.hotelName = response.hotelName;
          this.description = response.description;
        }
        else
        {
          this.router.navigate(['/admin/hotel/add']);
        }
      },
      (err: HttpErrorResponse)=>{
        this.router.navigate(['/admin/hotel/add']);
      }
    )
  }

  submit()
  {
    var hotel: any = {
      HotelName: this.hotelName,
      Description : this.description
    }

    this.hotelService.addHotel(hotel).subscribe(
      (response: any)=>{
          if (response) {
            this.router.navigate(['/admin/hotel/edit/' + response.hotelId]);
          }
      },
      (err: HttpErrorResponse)=>{}
    )
  }

}
