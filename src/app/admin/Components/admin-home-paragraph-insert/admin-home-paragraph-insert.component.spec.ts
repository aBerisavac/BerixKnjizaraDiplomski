import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminHomeParagraphInsertComponent } from './admin-home-paragraph-insert.component';

describe('AdminHomeParagraphInsertComponent', () => {
  let component: AdminHomeParagraphInsertComponent;
  let fixture: ComponentFixture<AdminHomeParagraphInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminHomeParagraphInsertComponent]
    });
    fixture = TestBed.createComponent(AdminHomeParagraphInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
