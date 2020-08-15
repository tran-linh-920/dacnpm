import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeclineCandidateComponent } from './decline-candidate.component';

describe('DeclineCandidateComponent', () => {
  let component: DeclineCandidateComponent;
  let fixture: ComponentFixture<DeclineCandidateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeclineCandidateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeclineCandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
