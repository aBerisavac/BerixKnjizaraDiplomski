import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminPanelTableComponent } from './admin-panel-table.component';

describe('AdminPanelTableComponent', () => {
  let component: AdminPanelTableComponent;
  let fixture: ComponentFixture<AdminPanelTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AdminPanelTableComponent]
    });
    fixture = TestBed.createComponent(AdminPanelTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
