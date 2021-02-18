import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BoutonReponseQcmComponent } from './bouton-reponse-qcm.component';

describe('BoutonReponseQcmComponent', () => {
  let component: BoutonReponseQcmComponent;
  let fixture: ComponentFixture<BoutonReponseQcmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BoutonReponseQcmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BoutonReponseQcmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
