import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectCompteCandidatComponent } from './select-compte-candidat.component';

describe('SelectCompteCandidatComponent', () => {
  let component: SelectCompteCandidatComponent;
  let fixture: ComponentFixture<SelectCompteCandidatComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectCompteCandidatComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectCompteCandidatComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
