import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PopupBottomRightComponent } from './popup-bottom-right.component';

describe('PopupBottomRightComponent', () => {
  let component: PopupBottomRightComponent;
  let fixture: ComponentFixture<PopupBottomRightComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PopupBottomRightComponent]
    });
    fixture = TestBed.createComponent(PopupBottomRightComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
