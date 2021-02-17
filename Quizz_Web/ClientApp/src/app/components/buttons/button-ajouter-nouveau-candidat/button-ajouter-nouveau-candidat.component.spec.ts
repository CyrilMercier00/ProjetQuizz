import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ButtonAjouterNouveauCandidatComponent } from './button-ajouter-nouveau-candidat.component';

describe('ButtonAjouterNouveauCandidatComponent', () => {
  let component: ButtonAjouterNouveauCandidatComponent;
  let fixture: ComponentFixture<ButtonAjouterNouveauCandidatComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ButtonAjouterNouveauCandidatComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ButtonAjouterNouveauCandidatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
