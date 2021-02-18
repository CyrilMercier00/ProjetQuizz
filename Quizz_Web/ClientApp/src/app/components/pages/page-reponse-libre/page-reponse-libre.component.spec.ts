import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageReponseLibreComponent } from './page-reponse-libre.component';

describe('PageReponseLibreComponent', () => {
  let component: PageReponseLibreComponent;
  let fixture: ComponentFixture<PageReponseLibreComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageReponseLibreComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageReponseLibreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
