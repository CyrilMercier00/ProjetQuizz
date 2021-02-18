import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EnonceComponent } from './enonce.component';

describe('EnonceComponent', () => {
  let component: EnonceComponent;
  let fixture: ComponentFixture<EnonceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EnonceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EnonceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
