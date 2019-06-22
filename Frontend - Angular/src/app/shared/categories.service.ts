import { HttpClient } from '@angular/common/http';
import { ICategory } from './../blog-categories/iCategory';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private url = 'https://localhost:44370/api/categories';
  constructor(private httpclient : HttpClient) { }

  getCategories() : Observable<ICategory[]>{
    return this.httpclient.get<ICategory[]>(this.url);
  }
}
