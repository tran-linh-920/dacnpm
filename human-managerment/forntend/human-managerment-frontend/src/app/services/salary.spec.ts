import { TestBed } from '@angular/core/testing';

import { SalaryHistoryService } from './salary-history.service';

describe('SalaryHistoryService', () => {
  let service: SalaryHistoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalaryHistoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
