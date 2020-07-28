import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimekeppingComponent } from './timekepping.component';

describe('TimekeppingComponent', () => {
  let component: TimekeppingComponent;
  let fixture: ComponentFixture<TimekeppingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimekeppingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimekeppingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
