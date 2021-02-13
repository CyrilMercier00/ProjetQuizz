import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignationQuizzComponent } from './assignation-quizz.component';

describe('AssignationQuizzComponent', () => {
  let component: AssignationQuizzComponent;
  let fixture: ComponentFixture<AssignationQuizzComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AssignationQuizzComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AssignationQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
