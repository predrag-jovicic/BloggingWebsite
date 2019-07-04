import { Observable, throwError } from 'rxjs';
import { map, tap, catchError } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from './ViewModels/IUser';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationserviceService {

  public get currentUser() : any{
    if(localStorage.getItem('loggedUser') != undefined){
      return JSON.parse(localStorage.getItem('loggedUser'));
    }
    else
      return null;
  }

  private url = 'https://localhost:44370/api/user';
  constructor(private http:HttpClient) { }

  logIn({username,password}){
    return this.http.post<any>(`${this.url}/login`,{username,password},{observe: 'response'});
  }

  logOut(){
    localStorage.removeItem('loggedUser');
  }
}
