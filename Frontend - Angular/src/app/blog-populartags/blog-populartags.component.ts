import { PostsService } from './../shared/posts.service';
import { TagsService } from './../shared/tags.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ITag } from './iTag';
import { Router, NavigationExtras } from '@angular/router';

@Component({
  selector: 'app-blog-populartags',
  templateUrl: './blog-populartags.component.html',
  styleUrls: ['./blog-populartags.component.css']
})
export class BlogPopulartagsComponent implements OnInit {
  private getPopularTagsService : TagsService;
  popularTags : ITag[];
  @Output() tagSelected = new EventEmitter<string>();
  constructor(getPopularTagsService : TagsService, private postsService : PostsService, private router : Router) {
    this.getPopularTagsService = getPopularTagsService;
  }

  ngOnInit() {
    this.getPopularTagsService.getPopularTags().subscribe(tags => this.popularTags = tags);
  }

  onClick($event){
    let navigationExtras: NavigationExtras = { 
      queryParams: { 'tag': $event.target.getAttribute("data-id")},
      queryParamsHandling: "merge"
    };
    this.router.navigate(['/home'],navigationExtras);
    return false;
  }

}
