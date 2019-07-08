import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogRecommendedpostsComponent } from './blog-recommendedposts.component';

describe('BlogRecommendedpostsComponent', () => {
  let component: BlogRecommendedpostsComponent;
  let fixture: ComponentFixture<BlogRecommendedpostsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogRecommendedpostsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogRecommendedpostsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
