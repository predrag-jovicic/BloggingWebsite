import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogPostpreviewComponent } from './blog-postpreview.component';

describe('BlogPostpreviewComponent', () => {
  let component: BlogPostpreviewComponent;
  let fixture: ComponentFixture<BlogPostpreviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogPostpreviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogPostpreviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
