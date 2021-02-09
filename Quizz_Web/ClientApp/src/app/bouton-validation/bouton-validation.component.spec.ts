import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BoutonValidationComponent } from './bouton-validation.component';

describe('BoutonValidationComponent', () => {
  let component: BoutonValidationComponent;
  let fixture: ComponentFixture<BoutonValidationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BoutonValidationComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BoutonValidationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
