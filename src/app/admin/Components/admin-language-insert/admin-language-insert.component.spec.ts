import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLanguageInsertComponent } from './admin-language-insert.component';

describe('AdminLanguageInsertComponent', () => {
  let component: AdminLanguageInsertComponent;
  let fixture: ComponentFixture<AdminLanguageInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminLanguageInsertComponent]
    });
    fixture = TestBed.createComponent(AdminLanguageInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
