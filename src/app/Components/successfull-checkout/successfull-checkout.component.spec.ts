import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccessfullCheckoutComponent } from './successfull-checkout.component';

describe('SuccessfullCheckoutComponent', () => {
  let component: SuccessfullCheckoutComponent;
  let fixture: ComponentFixture<SuccessfullCheckoutComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SuccessfullCheckoutComponent]
    });
    fixture = TestBed.createComponent(SuccessfullCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
