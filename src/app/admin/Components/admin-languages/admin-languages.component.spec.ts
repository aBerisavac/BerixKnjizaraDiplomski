import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminLanguagesComponent } from './admin-languages.component';

describe('AdminLanguagesComponent', () => {
  let component: AdminLanguagesComponent;
  let fixture: ComponentFixture<AdminLanguagesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminLanguagesComponent]
    });
    fixture = TestBed.createComponent(AdminLanguagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
