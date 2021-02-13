import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuizzQuestionComponent } from './quizz-question.component';

describe('QuizzQuestionComponent', () => {
  let component: QuizzQuestionComponent;
  let fixture: ComponentFixture<QuizzQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuizzQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuizzQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
