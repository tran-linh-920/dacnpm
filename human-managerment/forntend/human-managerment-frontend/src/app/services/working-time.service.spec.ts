import { TestBed } from '@angular/core/testing';

import { WorkingTimeService } from './working-time.service';

describe('WorkingTimeService', () => {
  let service: WorkingTimeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WorkingTimeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
