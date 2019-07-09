import { AuthenticationserviceService } from './authenticationservice.service';
import { IRecentPost } from '../blog-posts/blog-postpreview/IRecentPost';
import { Observable, Subject } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { IPost } from '../blog-posts/blog-postdetails/IPost';
import { IRecommendedPost } from '../blog-posts/blog-recommendedposts/IRecommendedPost';
import { INewPost } from './ViewModels/INewPost';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private url = 'https://localhost:44370/api/posts/';

  constructor(private httpClient : HttpClient, private authService : AuthenticationserviceService) { }

  getRecentPosts(filters) : Observable<IRecentPost[]>{
    return this.httpClient.get<IRecentPost[]>(this.url + "postspreview",{params:filters});
  }

  getPostDetails(id : number) : Observable<IPost>{
    return this.httpClient.get<IPost>(this.url + id);
  }

  getPostRecommendations(id:number): Observable<IRecommendedPost[]>{
    return this.httpClient.get<IRecommendedPost[]>(this.url + id + "/recommended");
  }

  createPost(post : INewPost){
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.authService.currentUser.token}`
      })
    };
    return this.httpClient.post<INewPost>(this.url,post,httpOptions);
  }

  deletePost(id){
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.authService.currentUser.token}`
      })
    };
    return this.httpClient.delete(this.url + id,httpOptions);
  }
}
