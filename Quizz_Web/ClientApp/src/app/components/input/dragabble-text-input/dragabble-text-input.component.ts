import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-dragabble-text-input',
  templateUrl: './dragabble-text-input.component.html',
  styleUrls: ['./dragabble-text-input.component.css']
})
export class DragabbleTextInputComponent implements OnInit
{
  @Output("text") textValueChange = new EventEmitter();
  @Input("title") title;

  constructor() { }

  valueChange(prmEvent)
  {
    this.textValueChange.emit(prmEvent.value)
  }

  ngOnInit()
  {
  }

}
