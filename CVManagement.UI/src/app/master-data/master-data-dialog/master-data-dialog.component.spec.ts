import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MasterDataDialogComponent } from './master-data-dialog.component';

describe('MasterDataDialogComponent', () => {
  let component: MasterDataDialogComponent;
  let fixture: ComponentFixture<MasterDataDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MasterDataDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MasterDataDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
