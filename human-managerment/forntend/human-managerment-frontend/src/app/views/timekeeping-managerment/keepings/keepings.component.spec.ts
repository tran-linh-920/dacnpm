import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KeepingsComponent } from './keepings.component';

describe('KeepingsComponent', () => {
  let component: KeepingsComponent;
  let fixture: ComponentFixture<KeepingsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KeepingsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KeepingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
