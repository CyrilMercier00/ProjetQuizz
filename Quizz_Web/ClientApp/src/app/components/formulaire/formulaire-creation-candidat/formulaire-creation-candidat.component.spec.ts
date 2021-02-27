import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaireCreationCandidatComponent } from './formulaire-creation-candidat.component';

describe('FormulaireCreationCandidatComponent', () => {
  let component: FormulaireCreationCandidatComponent;
  let fixture: ComponentFixture<FormulaireCreationCandidatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormulaireCreationCandidatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormulaireCreationCandidatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
