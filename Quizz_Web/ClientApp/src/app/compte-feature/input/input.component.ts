import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-input',
  templateUrl: './input.component.html',
  styleUrls: ['./input.component.css']
})
export class InputComponent implements OnInit {

  @Input()
  get text(): string {return this._text;}
  set text(text: string){
    this._text = text;
  }

  private _text = 'Salaud';

  constructor() { }

  ngOnInit() {
  }

}
