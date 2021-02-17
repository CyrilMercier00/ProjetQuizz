import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaireCreationCompteComponent } from './formulaire-creation-compte.component';

describe('FormulaireCreationCompteComponent', () => {
  let component: FormulaireCreationCompteComponent;
  let fixture: ComponentFixture<FormulaireCreationCompteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormulaireCreationCompteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormulaireCreationCompteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
