import { TestBed } from '@angular/core/testing';

import { ConectareAngularDotNetService } from './conectare-angular-dot-net.service';

describe('ConectareAngularDotNetService', () => {
  let service: ConectareAngularDotNetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConectareAngularDotNetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
