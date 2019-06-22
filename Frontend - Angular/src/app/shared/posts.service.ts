import { IRecentPost } from './../blog-postpreview/IRecentPost';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPost } from '../blog-postdetails/IPost';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private url = 'https://localhost:44370/api/posts/';
  constructor(private httpClient : HttpClient) { }

  getRecentPosts() : Observable<IRecentPost[]>{
    return this.httpClient.get<IRecentPost[]>(this.url + "postspreview");
  }

  getPostDetails(id) : Observable<IPost>{
    return this.httpClient.get<IPost>(this.url + id);
  }
}
