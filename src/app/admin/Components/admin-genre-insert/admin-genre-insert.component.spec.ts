import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminGenreInsertComponent } from './admin-genre-insert.component';

describe('AdminGenreInsertComponent', () => {
  let component: AdminGenreInsertComponent;
  let fixture: ComponentFixture<AdminGenreInsertComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminGenreInsertComponent]
    });
    fixture = TestBed.createComponent(AdminGenreInsertComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
