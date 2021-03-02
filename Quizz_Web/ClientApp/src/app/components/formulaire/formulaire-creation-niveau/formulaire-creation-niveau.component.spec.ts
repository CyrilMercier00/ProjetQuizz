import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaireCreationNiveauComponent } from './formulaire-creation-niveau.component';

describe('FormulaireCreationNiveauComponent', () => {
  let component: FormulaireCreationNiveauComponent;
  let fixture: ComponentFixture<FormulaireCreationNiveauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FormulaireCreationNiveauComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FormulaireCreationNiveauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
