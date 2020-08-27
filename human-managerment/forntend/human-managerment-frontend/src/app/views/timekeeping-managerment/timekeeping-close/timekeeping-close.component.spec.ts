import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimekeepingCloseComponent } from './timekeeping-close.component';

describe('TimekeepingCloseComponent', () => {
  let component: TimekeepingCloseComponent;
  let fixture: ComponentFixture<TimekeepingCloseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimekeepingCloseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimekeepingCloseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
