import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XBookComponent } from './x-book.component';

describe('XBookComponent', () => {
  let component: XBookComponent;
  let fixture: ComponentFixture<XBookComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [XBookComponent]
    });
    fixture = TestBed.createComponent(XBookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
