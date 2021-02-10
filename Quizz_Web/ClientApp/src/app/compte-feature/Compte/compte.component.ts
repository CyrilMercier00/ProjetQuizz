import { Component, OnInit } from '@angular/core';
import { Compte } from './compte.model';

@Component({
  selector: 'app-compte',
  templateUrl: './compte.component.html',
  styleUrls: ['./compte.component.css']
})
export class CompteComponent implements OnInit {

  _compte : Compte;

  constructor(private compte : Compte) {
    this._compte = compte;
   }

  ngOnInit(): void {
  }

}
