import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkingtimeComponent } from './workingtime.component';

describe('WorkingtimeComponent', () => {
  let component: WorkingtimeComponent;
  let fixture: ComponentFixture<WorkingtimeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkingtimeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkingtimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
