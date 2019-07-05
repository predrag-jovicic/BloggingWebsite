import { AuthenticationserviceService } from './authenticationservice.service';
import { Observable } from 'rxjs';
import { IComment } from './../blog-comments/IComment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  private url = 'https://localhost:44370/api/comments/';
  constructor(private httpClient : HttpClient, private authService : AuthenticationserviceService) { }

  getCommentsByPost(id) : Observable<IComment[]>{
    return this.httpClient.get<IComment[]>(this.url + 'post/' + id);
  }

  postComment(newComment){
    if(this.authService.currentUser != null){
      const httpOptions = {
        headers: new HttpHeaders({
          'Authorization': `Bearer ${this.authService.currentUser.token}`
        })
      };
      return this.httpClient.post(this.url,newComment,httpOptions);
    }
    else{
      return this.httpClient.post(this.url,newComment);
    }
  }
}
