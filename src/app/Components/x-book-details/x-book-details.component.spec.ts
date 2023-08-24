import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XBookDetailsComponent } from './x-book-details.component';

describe('XBookDetailsComponent', () => {
  let component: XBookDetailsComponent;
  let fixture: ComponentFixture<XBookDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [XBookDetailsComponent]
    });
    fixture = TestBed.createComponent(XBookDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
