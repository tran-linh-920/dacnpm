import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProviceComponent } from './provice.component';

describe('ProviceComponent', () => {
  let component: ProviceComponent;
  let fixture: ComponentFixture<ProviceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProviceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
