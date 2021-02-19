import { Component, Input, OnInit } from '@angular/core';
import { Compte } from './compte.model';

@Component({
  selector: 'app-compte',
  templateUrl: './compte.component.html',
  styleUrls: ['./compte.component.css']
})
export class CompteComponent implements OnInit {

  @Input() compte : Compte;
  
  constructor() {
  }

  ngOnInit(): void {
  }

}
