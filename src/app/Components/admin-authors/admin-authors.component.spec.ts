import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAuthorsComponent } from './admin-authors.component';

describe('AdminAuthorsComponent', () => {
  let component: AdminAuthorsComponent;
  let fixture: ComponentFixture<AdminAuthorsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminAuthorsComponent]
    });
    fixture = TestBed.createComponent(AdminAuthorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
