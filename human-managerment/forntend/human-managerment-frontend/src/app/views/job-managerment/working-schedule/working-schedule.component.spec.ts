import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkingScheduleComponent } from './working-schedule.component';

describe('WorkingScheduleComponent', () => {
  let component: WorkingScheduleComponent;
  let fixture: ComponentFixture<WorkingScheduleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkingScheduleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkingScheduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
