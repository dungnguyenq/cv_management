import { TestBed } from '@angular/core/testing';

import { CvEditorService } from './cv-editor.service';

describe('CvEditorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CvEditorService = TestBed.get(CvEditorService);
    expect(service).toBeTruthy();
  });
});
