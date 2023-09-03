import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLanguageUpdateComponent } from './admin-language-update.component';

describe('AdminLanguageUpdateComponent', () => {
  let component: AdminLanguageUpdateComponent;
  let fixture: ComponentFixture<AdminLanguageUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminLanguageUpdateComponent]
    });
    fixture = TestBed.createComponent(AdminLanguageUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
