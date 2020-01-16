import { TestBed } from '@angular/core/testing';

import { MasterDataService } from './master-data.service';

describe('MasterDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MasterDataService = TestBed.get(MasterDataService);
    expect(service).toBeTruthy();
  });
});
