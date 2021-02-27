import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenQuizzComponent } from './gen-quizz.component';

describe('GenQuizzComponent', () => {
  let component: GenQuizzComponent;
  let fixture: ComponentFixture<GenQuizzComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenQuizzComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
