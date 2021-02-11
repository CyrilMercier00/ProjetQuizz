import { Component, OnInit } from '@angular/core';
import { Compte } from '../Compte/compte.model';
import { CompteService } from '../Compte/compte.service';

@Component({
  selector: 'app-comptes',
  templateUrl: './comptes.component.html',
  styleUrls: ['./comptes.component.css']
})
export class ComptesComponent implements OnInit {

  comptes: Compte[] = [];

  constructor(private compteService : CompteService) { }

  ngOnInit(): void {
    console.log('coucou');
    this.compteService.getAll().subscribe(response => {
      this.comptes = response;
      console.log(this.comptes);
    });
  }
}
