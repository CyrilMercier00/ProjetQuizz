import { Component, OnInit } from '@angular/core';
import { Globals } from 'src/app/globals';
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
    const requestHeaders: HeadersInit = new Headers();
  
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());

    await fetch(VariableGlobales.apiURLComplexite, { method: "GET" , headers: requestHeaders})
      .then((response) => response.json())
      .then((json) =>
      {
        this.valRetourRequeteComplex = json;
      });
      console.log(this.valRetourRequeteComplex);
  }

  async supprimerNiveau(id){
    const requestHeaders: HeadersInit = new Headers();
  
    requestHeaders.set('Content-Type', 'application/json');
    requestHeaders.set('Authorization', Globals.getJwt());
    
    await fetch(VariableGlobales.apiURLComplexite + id, { method: "DELETE" , headers: requestHeaders})
    .then(res => res.json()) 
.then(res => console.log(res))
    
  }
  
}
