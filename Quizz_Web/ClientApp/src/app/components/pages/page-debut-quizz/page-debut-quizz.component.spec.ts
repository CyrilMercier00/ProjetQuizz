import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageDebutQuizzComponent } from './page-debut-quizz.component';

describe('PageDebutQuizzComponent', () => {
  let component: PageDebutQuizzComponent;
  let fixture: ComponentFixture<PageDebutQuizzComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageDebutQuizzComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageDebutQuizzComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
