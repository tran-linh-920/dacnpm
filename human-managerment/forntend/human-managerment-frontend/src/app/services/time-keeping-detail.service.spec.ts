import { TestBed } from '@angular/core/testing';

import { TimeKeepingDetailService } from './time-keeping-detail.service';

describe('TimeKeepingDetailService', () => {
  let service: TimeKeepingDetailService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TimeKeepingDetailService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
