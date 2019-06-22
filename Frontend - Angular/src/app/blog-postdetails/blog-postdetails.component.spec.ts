import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogPostdetailsComponent } from './blog-postdetails.component';

describe('BlogPostdetailsComponent', () => {
  let component: BlogPostdetailsComponent;
  let fixture: ComponentFixture<BlogPostdetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogPostdetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPostdetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
