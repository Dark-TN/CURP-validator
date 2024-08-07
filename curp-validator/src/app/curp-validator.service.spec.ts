import { TestBed } from '@angular/core/testing';

import { CurpValidatorService } from './curp-validator.service';

describe('CurpValidatorService', () => {
  let service: CurpValidatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurpValidatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
