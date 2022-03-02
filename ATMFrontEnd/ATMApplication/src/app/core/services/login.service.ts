import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationModel, User } from 'src/app/core/model/index';

@Injectable({
  providedIn: 'root'
})
export class LoginService {


  constructor(private http: HttpClient) {

    
  }

  getUserDetails(credential: AuthenticationModel) : Observable<User> {
    const headers = {  'Content-Type': 'application/json'}  
    const body = JSON.stringify(credential);
     return this.http.post<User>('https://localhost:44371/api/user', body,{'headers':headers});

  }
  logout(){
    localStorage.removeItem('accountnumber');
  }
}
