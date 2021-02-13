import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonValidComponent } from './button-valid.component';

describe('ButtonValidComponent', () => {
  let component: ButtonValidComponent;
  let fixture: ComponentFixture<ButtonValidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ButtonValidComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ButtonValidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
