import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminHomeParagraphUpdateComponent } from './admin-home-paragraph-update.component';

describe('AdminHomeParagraphUpdateComponent', () => {
  let component: AdminHomeParagraphUpdateComponent;
  let fixture: ComponentFixture<AdminHomeParagraphUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminHomeParagraphUpdateComponent]
    });
    fixture = TestBed.createComponent(AdminHomeParagraphUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
