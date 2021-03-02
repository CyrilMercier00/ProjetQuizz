import { Component, OnInit } from '@angular/core';
import { timeStamp } from 'console';
import { VariableGlobales } from 'src/app/url_api';
import { DTOQuizz } from 'src/app/DTO/dto-quizz';

import { Stopwatch } from "ts-stopwatch";

@Component({
  selector: 'app-chrono',
  templateUrl: './chrono.component.html',
  styleUrls: ['./chrono.component.css']
})
export class ChronoComponent implements OnInit
{

  constructor() { }

  ngOnInit(): void
  {
    start();
  }

 //Appel dans button submit
 OnSubmitQuest(){
  let TQuest=new Date;
    TQuest.setHours(h);
    TQuest.setMinutes(mn);
    TQuest.setSeconds(s);
    clearInterval(t);
    let TimeQ=TQuest.getTime();
    //test affichege d
    //H[0].innerHTML="TQuest : " + d; 
    reset();
 }

 /* --- Envoi a l'api de la quizz ---*/
/* InsertQuestion(data)
 {

   let q = new DTOQuizz();
   q.$Chrono = data.value;
   

   fetch(
     VariableGlobales.apiURLQuizz+"OnsIwz28FkJiLVq9Ak5A",
     {
       method: "PUT",
       headers:
       {
         'Accept': 'application/json',
         'Content-Type': 'application/json'
       },
       body: JSON.stringify(q)
     }
   )
 }
  */

}


/*la fonction getElementByTagName renvoie une liste des éléments portant le nom de balise donné ici "span".*/
var sp = document.getElementsByClassName("spanChrono");
var H = document.getElementsByClassName("h5Chrono");
var t;
var ms = 0, s = 0, mn = 0, h = 0;

/*La fonction "start" démarre un appel répétitive de la fonction update_chrono par une cadence de 100 milliseconde en utilisant setInterval et désactive le bouton "start" */

function start()
{
  t = setInterval(update_chrono, 100);


}
/*La fonction update_chrono incrémente le nombre de millisecondes par 1 <==> 1*cadence = 100 */
function update_chrono()
{
  ms += 1;
  /*si ms=10 <==> ms*cadence = 1000ms <==> 1s alors on incrémente le nombre de secondes*/
     if(ms==10){
      ms=1;
      s+=1;
     }
     /*on teste si s=60 pour incrémenter le nombre de minute*/
     if(s==60){
      s=0;
      mn+=1;
     }
     if(mn==60){
      mn=0;
      h+=1;
     }
     /*afficher les nouvelle valeurs*/
     sp[0].innerHTML=h+" h";
     sp[1].innerHTML=mn+" min";
     sp[2].innerHTML=s+" s";
    // sp[3].innerHTML=ms+" ms";

}
//***on arrête le "timer" par clearInterval ,on réactive le bouton start 
function reset(){
  clearInterval(t);
   ms=0,s=0,mn=0,h=0;
  // ***on accède aux différents span par leurs indice***
   sp[0].innerHTML=h+" h";
   sp[1].innerHTML=mn+" min";
   sp[2].innerHTML=s+" s";
     }
/*pas besoin de reset


**dans cette fonction on arrête le "timer" ,on réactive le bouton "start" et on initialise les variables à zéro
function reset(){
clearInterval(t);
  ms=0,s=0,mn=0,h=0;
  ***on accède aux différents span par leurs indice***
  sp[0].innerHTML=h+" h";
  sp[1].innerHTML=mn+" min";
  sp[2].innerHTML=s+" s";
  sp[3].innerHTML=ms+" ms";
    }

     stop(){
     let date=new Date();
     date.setHours(h);
     date.setMinutes(mn);
     date.setSeconds(s);
     clearInterval(t);
  }
*/


