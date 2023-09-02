import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminBookUpdateComponent } from './admin-book-update.component';

describe('AdminBookUpdateComponent', () => {
  let component: AdminBookUpdateComponent;
  let fixture: ComponentFixture<AdminBookUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminBookUpdateComponent]
    });
    fixture = TestBed.createComponent(AdminBookUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
