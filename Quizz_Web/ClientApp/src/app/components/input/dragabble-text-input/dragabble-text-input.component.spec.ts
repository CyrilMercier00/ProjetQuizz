import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DragabbleTextInputComponent } from './dragabble-text-input.component';

describe('DragabbleTextInputComponent', () => {
  let component: DragabbleTextInputComponent;
  let fixture: ComponentFixture<DragabbleTextInputComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DragabbleTextInputComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DragabbleTextInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
