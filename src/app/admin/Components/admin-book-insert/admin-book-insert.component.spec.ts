import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBookInsertComponent } from './admin-book-insert.component';

describe('AdminBookInsertComponent', () => {
  let component: AdminBookInsertComponent;
  let fixture: ComponentFixture<AdminBookInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminBookInsertComponent]
    });
    fixture = TestBed.createComponent(AdminBookInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
