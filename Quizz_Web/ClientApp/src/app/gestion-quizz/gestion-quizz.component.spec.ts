import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GestionQuizzComponent } from './gestion-quizz.component';

describe('GestionQuizzComponent', () => {
  let component: GestionQuizzComponent;
  let fixture: ComponentFixture<GestionQuizzComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GestionQuizzComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GestionQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
