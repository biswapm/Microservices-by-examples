import { TestBed, inject } from '@angular/core/testing';

import { RoomImageService } from './room-image.service';

describe('RoomImageService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [RoomImageService]
    });
  });

  it('should be created', inject([RoomImageService], (service: RoomImageService) => {
    expect(service).toBeTruthy();
  }));
});
