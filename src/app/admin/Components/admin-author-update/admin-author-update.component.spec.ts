import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAuthorUpdateComponent } from './admin-author-update.component';

describe('AdminAuthorUpdateComponent', () => {
  let component: AdminAuthorUpdateComponent;
  let fixture: ComponentFixture<AdminAuthorUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminAuthorUpdateComponent]
    });
    fixture = TestBed.createComponent(AdminAuthorUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
