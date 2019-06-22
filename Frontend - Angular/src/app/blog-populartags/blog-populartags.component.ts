import { TagsService } from './../shared/tags.service';
import { Component, OnInit } from '@angular/core';
import { ITag } from './iTag';

@Component({
  selector: 'app-blog-populartags',
  templateUrl: './blog-populartags.component.html',
  styleUrls: ['./blog-populartags.component.css']
})
export class BlogPopulartagsComponent implements OnInit {
  private getPopularTagsService : TagsService;
  popularTags : ITag[];
  constructor(getPopularTagsService : TagsService ) {
    this.getPopularTagsService = getPopularTagsService;
  }

  ngOnInit() {
    this.getPopularTagsService.getPopularTags().subscribe(tags => this.popularTags = tags);
  }

  onClick($event){
    console.log($event.target.getAttribute("data-id"));
  }

}
