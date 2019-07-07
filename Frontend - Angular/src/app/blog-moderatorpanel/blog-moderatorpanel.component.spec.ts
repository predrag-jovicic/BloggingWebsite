import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BlogModeratorpanelComponent } from './blog-moderatorpanel.component';

describe('BlogModeratorpanelComponent', () => {
  let component: BlogModeratorpanelComponent;
  let fixture: ComponentFixture<BlogModeratorpanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BlogModeratorpanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BlogModeratorpanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
