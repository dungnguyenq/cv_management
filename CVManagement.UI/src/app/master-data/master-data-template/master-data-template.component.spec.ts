import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MasterDataTemplateComponent } from './master-data-template.component';

describe('MasterDataTemplateComponent', () => {
  let component: MasterDataTemplateComponent;
  let fixture: ComponentFixture<MasterDataTemplateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MasterDataTemplateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MasterDataTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
