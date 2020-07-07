import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobInfomationComponent } from './job-infomation.component';

describe('JobInfomationComponent', () => {
  let component: JobInfomationComponent;
  let fixture: ComponentFixture<JobInfomationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobInfomationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobInfomationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
