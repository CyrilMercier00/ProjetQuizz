import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListeQuizzComponent } from './liste-quizz.component';

describe('ListeQuizzComponent', () => {
  let component: ListeQuizzComponent;
  let fixture: ComponentFixture<ListeQuizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListeQuizzComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListeQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
