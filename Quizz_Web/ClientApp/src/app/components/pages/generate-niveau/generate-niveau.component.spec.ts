import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenerateNiveauComponent } from './generate-niveau.component';

describe('GenerateNiveauComponent', () => {
  let component: GenerateNiveauComponent;
  let fixture: ComponentFixture<GenerateNiveauComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenerateNiveauComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenerateNiveauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
