import { Observable } from 'rxjs';
import { IComment } from './../blog-comments/IComment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  private url = 'https://localhost:44370/api/comments/';
  constructor(private httpClient : HttpClient) { }

  getCommentsByPost(id) : Observable<IComment[]>{
    return this.httpClient.get<IComment[]>(this.url + 'post/' + id);
  }
}
