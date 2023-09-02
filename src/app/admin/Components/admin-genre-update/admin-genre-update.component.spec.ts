import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminGenreUpdateComponent } from './admin-genre-update.component';

describe('AdminGenreUpdateComponent', () => {
  let component: AdminGenreUpdateComponent;
  let fixture: ComponentFixture<AdminGenreUpdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminGenreUpdateComponent]
    });
    fixture = TestBed.createComponent(AdminGenreUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
