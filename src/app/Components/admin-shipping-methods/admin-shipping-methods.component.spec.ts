import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminShippingMethodsComponent } from './admin-shipping-methods.component';

describe('AdminShippingMethodsComponent', () => {
  let component: AdminShippingMethodsComponent;
  let fixture: ComponentFixture<AdminShippingMethodsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminShippingMethodsComponent]
    });
    fixture = TestBed.createComponent(AdminShippingMethodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
