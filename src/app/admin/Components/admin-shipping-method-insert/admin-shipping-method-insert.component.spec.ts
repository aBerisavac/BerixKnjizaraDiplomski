import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminShippingMethodInsertComponent } from './admin-shipping-method-insert.component';

describe('AdminShippingMethodInsertComponent', () => {
  let component: AdminShippingMethodInsertComponent;
  let fixture: ComponentFixture<AdminShippingMethodInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminShippingMethodInsertComponent]
    });
    fixture = TestBed.createComponent(AdminShippingMethodInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
