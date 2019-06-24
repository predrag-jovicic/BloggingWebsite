import { PostsService } from './../shared/posts.service';
import { TagsService } from './../shared/tags.service';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ITag } from './iTag';

@Component({
  selector: 'app-blog-populartags',
  templateUrl: './blog-populartags.component.html',
  styleUrls: ['./blog-populartags.component.css']
})
export class BlogPopulartagsComponent implements OnInit {
  private getPopularTagsService : TagsService;
  popularTags : ITag[];
  @Output() tagSelected = new EventEmitter<string>();
  constructor(getPopularTagsService : TagsService, private postsService : PostsService) {
    this.getPopularTagsService = getPopularTagsService;
  }

  ngOnInit() {
    this.getPopularTagsService.getPopularTags().subscribe(tags => this.popularTags = tags);
  }

  onClick($event){
    this.postsService.invokeGetRecentPostsByTag($event.target.getAttribute("data-id"));
    this.tagSelected.emit();
  }

}
