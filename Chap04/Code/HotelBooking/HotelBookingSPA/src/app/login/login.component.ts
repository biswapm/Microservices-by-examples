import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

import { UserService } from '../service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [UserService]
})
export class LoginComponent implements OnInit {

   email: string;
   password: string;

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  login() {
    this.userService.userAuth(this.email, this.password).subscribe(
      (data) => {

        // sessionStorage.setItem("auth_access_token", data.access_token);
        
        // this.userService.getPartnerProfile().subscribe(
        //   (userInfo: any)=>{
        //     if (userInfo.IsSuccess) {
        //       if (userInfo.Data) {
        //         // Store User name in Session.
        //         sessionStorage.setItem("auth_user_name", userInfo.Data.Name);
        //         this.userService.changeLoggedInUser(userInfo.Data.Name);

        //         this.router.navigate(['/dashboard']);
        //       }
        //     }
        //   },
        //   (err: HttpErrorResponse)=>{}
        // );

        //this.router.navigateByUrl('/dashboard');
      },
      (err: HttpErrorResponse)=>{
        alert(err.message);
      }
    );
  }

}
