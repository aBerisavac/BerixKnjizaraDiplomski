import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminHomeParagraphsComponent } from './admin-home-paragraphs.component';

describe('AdminHomeParagraphsComponent', () => {
  let component: AdminHomeParagraphsComponent;
  let fixture: ComponentFixture<AdminHomeParagraphsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminHomeParagraphsComponent]
    });
    fixture = TestBed.createComponent(AdminHomeParagraphsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
