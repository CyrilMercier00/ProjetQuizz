import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageReponseQcmComponent } from './page-reponse-qcm.component';

describe('PageReponseQcmComponent', () => {
  let component: PageReponseQcmComponent;
  let fixture: ComponentFixture<PageReponseQcmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageReponseQcmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageReponseQcmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
