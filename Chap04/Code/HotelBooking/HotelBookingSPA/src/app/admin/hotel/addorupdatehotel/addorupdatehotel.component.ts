import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/filter';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-addorupdatehotel',
  templateUrl: './addorupdatehotel.component.html',
  styleUrls: ['./addorupdatehotel.component.css']
})
export class AddorupdatehotelComponent implements OnInit {

  hotelName: string;
  description: string;

  constructor() { }

  ngOnInit() {
  }

}
