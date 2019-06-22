import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogPopulartagsComponent } from './blog-populartags.component';

describe('BlogPopulartagsComponent', () => {
  let component: BlogPopulartagsComponent;
  let fixture: ComponentFixture<BlogPopulartagsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogPopulartagsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPopulartagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
