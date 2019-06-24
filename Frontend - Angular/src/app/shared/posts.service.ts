import { IRecentPost } from './../blog-postpreview/IRecentPost';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { IPost } from '../blog-postdetails/IPost';

@Injectable({
  providedIn: 'root'
})
export class PostsService {
  private url = 'https://localhost:44370/api/posts';

  private recentPostsByTagSource = new Subject<IRecentPost[]>();
  recentPostsByTag$ = this.recentPostsByTagSource.asObservable();

  private recentPostsByCategorySource = new Subject<IRecentPost[]>();
  recentPostsByCategory$ = this.recentPostsByCategorySource.asObservable();

  constructor(private httpClient : HttpClient) { }

  getRecentPosts() : Observable<IRecentPost[]>{
    return this.httpClient.get<IRecentPost[]>(this.url + "/postspreview");
  }

  getPostDetails(id) : Observable<IPost>{
    return this.httpClient.get<IPost>(this.url + '/' + id);
  }

  getRecentPostsByTag(id:number) : Observable<IRecentPost[]>{
    return this.httpClient.get<IRecentPost[]>(this.url + "/postspreview?tag=" + id);
  }

  getRecentPostsByCategory(id:number) : Observable<IRecentPost[]>{
    return this.httpClient.get<IRecentPost[]>(this.url + "/postspreview?category=" + id);
  }

  invokeGetRecentPostsByTag(id){
    this.getRecentPostsByTag(id).subscribe(posts => this.recentPostsByTagSource.next(posts));
  }

  invokeGetRecentPostsByCategory(id){
    this.getRecentPostsByCategory(id).subscribe(posts => this.recentPostsByCategorySource.next(posts));
  }
}
