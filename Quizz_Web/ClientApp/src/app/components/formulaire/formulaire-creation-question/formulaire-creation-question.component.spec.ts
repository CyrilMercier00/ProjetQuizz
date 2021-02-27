import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormulaireAjoutQuestionBddComponent } from './formulaire-creation-question.component';

describe('FormulaireAjoutQuestionBddComponent', () => {
  let component: FormulaireAjoutQuestionBddComponent;
  let fixture: ComponentFixture<FormulaireAjoutQuestionBddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormulaireAjoutQuestionBddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormulaireAjoutQuestionBddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
