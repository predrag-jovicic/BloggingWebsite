import { Injectable } from '@angular/core';
import { ITag } from '../blog-populartags/iTag';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TagsService {
  private url = 'https://localhost:44370/api/tags/popular';

  constructor(private http: HttpClient) { }

  getPopularTags() : Observable<ITag[]>{
      return this.http.get<ITag[]>(this.url);
  }
}
