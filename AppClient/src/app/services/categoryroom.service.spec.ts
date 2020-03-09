import { TestBed } from '@angular/core/testing';

import { CategoryroomService } from './categoryroom.service';

describe('CategoryroomService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CategoryroomService = TestBed.get(CategoryroomService);
    expect(service).toBeTruthy();
  });
});
