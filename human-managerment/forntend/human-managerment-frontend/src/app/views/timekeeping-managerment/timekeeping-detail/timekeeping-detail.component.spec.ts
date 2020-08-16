import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimekeepingDetailComponent } from './timekeeping-detail.component';

describe('TimekeepingDetailComponent', () => {
  let component: TimekeepingDetailComponent;
  let fixture: ComponentFixture<TimekeepingDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimekeepingDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimekeepingDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
