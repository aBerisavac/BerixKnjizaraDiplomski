import { ComponentFixture, TestBed } from '@angular/core/testing';

import { XAuthorDetailsComponent } from './x-author-details.component';

describe('XAuthorDetailsComponent', () => {
  let component: XAuthorDetailsComponent;
  let fixture: ComponentFixture<XAuthorDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [XAuthorDetailsComponent]
    });
    fixture = TestBed.createComponent(XAuthorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
