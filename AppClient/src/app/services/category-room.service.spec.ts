import { TestBed } from '@angular/core/testing';

import { CategoryRoomService } from './category-room.service';

describe('CategoryRoomService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CategoryRoomService = TestBed.get(CategoryRoomService);
    expect(service).toBeTruthy();
  });
});
