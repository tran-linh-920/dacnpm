import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaryIncreasingComponent } from './salary-increasing.component';

describe('SalaryIncreasingComponent', () => {
  let component: SalaryIncreasingComponent;
  let fixture: ComponentFixture<SalaryIncreasingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalaryIncreasingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaryIncreasingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
