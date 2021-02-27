import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageCreationQuestionComponent } from './page-creation-question.component';

describe('PageCreationQuestionComponent', () => {
  let component: PageCreationQuestionComponent;
  let fixture: ComponentFixture<PageCreationQuestionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageCreationQuestionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageCreationQuestionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
