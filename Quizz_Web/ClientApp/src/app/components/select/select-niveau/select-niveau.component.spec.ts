import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectNiveauComponent } from './select-niveau.component';

describe('SelectNiveauComponent', () =>
{
  let component: SelectNiveauComponent;
  let fixture: ComponentFixture<SelectNiveauComponent>;

  beforeEach(async(() =>
  {
    TestBed.configureTestingModule({
      declarations: [ SelectNiveauComponent ]
    })
      .compileComponents();
  }));

  beforeEach(() =>
  {
    fixture = TestBed.createComponent(SelectNiveauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () =>
  {
    expect(component).toBeTruthy();
  });
});
