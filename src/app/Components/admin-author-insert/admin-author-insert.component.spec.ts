import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminAuthorInsertComponent } from './admin-author-insert.component';

describe('AdminAuthorInsertComponent', () => {
  let component: AdminAuthorInsertComponent;
  let fixture: ComponentFixture<AdminAuthorInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminAuthorInsertComponent]
    });
    fixture = TestBed.createComponent(AdminAuthorInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
