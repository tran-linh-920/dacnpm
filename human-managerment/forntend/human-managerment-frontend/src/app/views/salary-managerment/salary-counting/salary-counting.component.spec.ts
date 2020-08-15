import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryCountingComponent } from './salary-counting.component';

describe('SalaryCountingComponent', () => {
  let component: SalaryCountingComponent;
  let fixture: ComponentFixture<SalaryCountingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalaryCountingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaryCountingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
