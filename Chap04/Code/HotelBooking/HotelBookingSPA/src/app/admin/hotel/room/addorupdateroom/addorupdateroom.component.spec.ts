import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddorupdateroomComponent } from './addorupdateroom.component';

describe('AddorupdateroomComponent', () => {
  let component: AddorupdateroomComponent;
  let fixture: ComponentFixture<AddorupdateroomComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddorupdateroomComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddorupdateroomComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
