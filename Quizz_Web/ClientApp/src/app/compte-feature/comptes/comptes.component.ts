import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Compte } from '../Compte/compte.model';
import { CompteService } from '../Compte/compte.service';

@Component({
  selector: 'app-comptes',
  templateUrl: './comptes.component.html',
  styleUrls: ['./comptes.component.css']
})
export class ComptesComponent implements OnInit {

  comptes: Compte[] = [];

  constructor(private compteService : CompteService, private router: Router) { }

  ngOnInit(): void {
    this.compteService.getAll().subscribe(response => {
      this.comptes = response;
    });
  }

  refresh(): void{
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    }); 
  }
}
