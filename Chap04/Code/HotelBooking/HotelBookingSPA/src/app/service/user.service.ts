import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders  } from '@angular/common/http';

import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { HttpErrorHandler, HandleError } from '../http-error-handler.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  appApiUrl: string = "https://localhost:44379/api/";  

  private handleError: HandleError;

  constructor(private http: HttpClient, httpErrorHandler: HttpErrorHandler) { 
    this.handleError = httpErrorHandler.createHandleError('UserService');
  }

  userAuth(userName: string, password: string) {  

    var data: any = {
      UserName : userName,
      Password:  password 
    }

    var reqHeaders = new HttpHeaders({
      'Content-Type':  'application/json'
    })

    var url = this.appApiUrl + "auth/login";

    return this.http.post(url, data, {headers: reqHeaders });
    // .pipe(
    //   catchError(this.handleError('userAuth', tempAuthInfo))
    // );
  }
}
