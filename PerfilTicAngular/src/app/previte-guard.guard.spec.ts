import { TestBed } from '@angular/core/testing';

import { PreviteGuardGuard } from './previte-guard.guard';

describe('PreviteGuardGuard', () => {
  let guard: PreviteGuardGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(PreviteGuardGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
