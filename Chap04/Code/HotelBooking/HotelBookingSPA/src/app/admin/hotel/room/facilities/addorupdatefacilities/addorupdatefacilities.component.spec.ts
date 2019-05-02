import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddorupdatefacilitiesComponent } from './addorupdatefacilities.component';

describe('AddorupdatefacilitiesComponent', () => {
  let component: AddorupdatefacilitiesComponent;
  let fixture: ComponentFixture<AddorupdatefacilitiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddorupdatefacilitiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddorupdatefacilitiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
