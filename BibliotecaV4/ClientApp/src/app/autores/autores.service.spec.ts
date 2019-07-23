import { TestBed, inject } from '@angular/core/testing';

import { AutoresService } from './autores.service';

describe('AutoresService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AutoresService]
    });
  });

  it('should be created', inject([AutoresService], (service: AutoresService) => {
    expect(service).toBeTruthy();
  }));
});
