import { IRecentPost } from './../blog-postpreview/IRecentPost';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { IPost } from '../blog-postdetails/IPost';
import { IRecommendedPost } from '../blog-recommendedposts/IRecommendedPost';
import { QueryParam } from '../blog-postpreview/QueryParam';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private url = 'https://localhost:44370/api/posts/';

  constructor(private httpClient : HttpClient) { }

  getRecentPosts(filters) : Observable<IRecentPost[]>{
    return this.httpClient.get<IRecentPost[]>(this.url + "postspreview",{params:filters});
  }

  getPostDetails(id : number) : Observable<IPost>{
    return this.httpClient.get<IPost>(this.url + id);
  }

  getPostRecommendations(id:number): Observable<IRecommendedPost[]>{
    return this.httpClient.get<IRecommendedPost[]>(this.url + id + "/recommended");
  }
}
