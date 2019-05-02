import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddorupdatehotelComponent } from './addorupdatehotel.component';

describe('AddorupdatehotelComponent', () => {
  let component: AddorupdatehotelComponent;
  let fixture: ComponentFixture<AddorupdatehotelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddorupdatehotelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddorupdatehotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
