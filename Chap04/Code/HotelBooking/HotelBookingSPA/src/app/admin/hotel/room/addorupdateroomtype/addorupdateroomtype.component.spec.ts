import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddorupdateroomtypeComponent } from './addorupdateroomtype.component';

describe('AddorupdateroomtypeComponent', () => {
  let component: AddorupdateroomtypeComponent;
  let fixture: ComponentFixture<AddorupdateroomtypeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddorupdateroomtypeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddorupdateroomtypeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
