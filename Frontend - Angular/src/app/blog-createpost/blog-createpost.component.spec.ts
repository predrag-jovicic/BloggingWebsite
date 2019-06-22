import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogCreatepostComponent } from './blog-createpost.component';

describe('BlogCreatepostComponent', () => {
  let component: BlogCreatepostComponent;
  let fixture: ComponentFixture<BlogCreatepostComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogCreatepostComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogCreatepostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
