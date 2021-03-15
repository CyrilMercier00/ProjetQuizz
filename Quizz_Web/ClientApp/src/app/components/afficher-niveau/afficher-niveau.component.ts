import { Component, OnInit } from '@angular/core';
import { VariableGlobales } from 'src/app/url_api';

@Component({
  selector: 'app-afficher-niveau',
  templateUrl: './afficher-niveau.component.html',
  styleUrls: ['./afficher-niveau.component.css']
})
export class AfficherNiveauComponent implements OnInit {
  valRetourRequeteComplex: string;  
  
  constructor() { }

  ngOnInit(): void {
    this.getAllComplexite();
  }
  async  getAllComplexite()
  {
    await fetch(VariableGlobales.apiURLComplexite, { method: "GET" })
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteComplex = json;
      });
      console.log(this.valRetourRequeteComplex);
  }

  async supprimerNiveau(id){
    await fetch(VariableGlobales.apiURLComplexite + id, { method: "DELETE" })
    .then(res => res.json()) 
.then(res => console.log(res))
    
  }
  
}
