import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminShippingMethodUpdateComponent } from './admin-shipping-method-update.component';

describe('AdminShippingMethodUpdateComponent', () => {
  let component: AdminShippingMethodUpdateComponent;
  let fixture: ComponentFixture<AdminShippingMethodUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminShippingMethodUpdateComponent]
    });
    fixture = TestBed.createComponent(AdminShippingMethodUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
