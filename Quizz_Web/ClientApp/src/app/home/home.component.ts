import { Component, Output } from '@angular/core';
import { Router } from '@angular/router';
import { EventEmitter } from 'events';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  
  public constructor(private router : Router){}

  redirectToHome(){
    this.router.navigate(['/']);
  }

  isOpen = false;

  onClick(click: boolean){
    this.isOpen = click;
  }
}
