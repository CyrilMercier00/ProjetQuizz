import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModificationQuizzComponent } from './modification-quizz.component';

describe('ModificationQuizzComponent', () => {
  let component: ModificationQuizzComponent;
  let fixture: ComponentFixture<ModificationQuizzComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModificationQuizzComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModificationQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
