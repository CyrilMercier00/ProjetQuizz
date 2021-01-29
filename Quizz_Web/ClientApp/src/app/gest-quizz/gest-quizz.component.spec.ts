import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestQuizzComponent } from './gest-quizz.component';

describe('GestQuizzComponent', () => {
  let component: GestQuizzComponent;
  let fixture: ComponentFixture<GestQuizzComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestQuizzComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
