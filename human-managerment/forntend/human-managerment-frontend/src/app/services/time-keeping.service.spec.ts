import { TestBed } from '@angular/core/testing';

import { TimeKeepingService } from './time-keeping.service';

describe('TimeKeepingService', () => {
  let service: TimeKeepingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TimeKeepingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
