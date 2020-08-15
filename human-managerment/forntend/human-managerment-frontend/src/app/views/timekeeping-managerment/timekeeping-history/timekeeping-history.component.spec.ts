import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimekeepingHistoryComponent } from './timekeeping-history.component';

describe('TimekeepingHistoryComponent', () => {
  let component: TimekeepingHistoryComponent;
  let fixture: ComponentFixture<TimekeepingHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimekeepingHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimekeepingHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
