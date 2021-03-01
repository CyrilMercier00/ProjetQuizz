import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chronometre',
  templateUrl: './chronometre.component.html',
  styleUrls: ['./chronometre.component.css']
})
export class ChronometreComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    var dateStart = new Date;
    dateStart.setHours(0);
    dateStart.setMinutes(0);
    dateStart.setSeconds(0);
    chronometre(dateStart);
  }

  

}
var  dateT= new Date;
var digitSegments = [
  [1, 2, 3, 4, 5, 6],
  [2, 3],
  [1, 2, 7, 5, 4],
  [1, 2, 7, 3, 4],
  [6, 7, 2, 3],
  [1, 6, 7, 3, 4],
  [1, 6, 5, 4, 3, 7],
  [1, 2, 3],
  [1, 2, 3, 4, 5, 6, 7],
  [1, 2, 7, 3, 6]
];



  var setNumber = function (digit, number, on) {
  var segments = digit.querySelectorAll(".segment");
  var current = parseInt(digit.getAttribute("data-value"));

  // only switch if number has changed or wasn't set
  if (!isNaN(current) && current != number) {
    // unset previous number
    digitSegments[current].forEach(function (digitSegment, index) {
      setTimeout(function () {
        segments[digitSegment - 1].classList.remove("on");
      }, index * 45);
    });
  }

  if (isNaN(current) || current != number) {
    // set new number after
    setTimeout(function () {
      digitSegments[number].forEach(function (digitSegment, index) {
        setTimeout(function () {
          segments[digitSegment - 1].classList.add("on");
        }, index * 45);
      });
    }, 250);
    digit.setAttribute("data-value", number);
  }
};
function chronometre(dateStart:Date) {
  document.addEventListener("DOMContentLoaded", function () {
  
    var _hours = document.querySelectorAll(".hours");
    var _minutes = document.querySelectorAll(".minutes");
    var _seconds = document.querySelectorAll(".seconds");

    setInterval(function () {
      var dateT1 = new Date();
      
      var hours = dateStart.getHours()+(dateT1.getHours()-dateT.getHours()),
        minutes = dateStart.getMinutes()+(dateT1.getMinutes()-dateT.getMinutes()),
        seconds = dateStart.getSeconds()+(dateT1.getSeconds());

      

      setNumber(_hours[0], Math.floor(hours / 10), 1);
      setNumber(_hours[1], hours % 10, 1);

      setNumber(_minutes[0], Math.floor(minutes / 10), 1);
      setNumber(_minutes[1], minutes % 10, 1);

      setNumber(_seconds[0], Math.floor(seconds / 10), 1);
      setNumber(_seconds[1], seconds % 10, 1);
    }, 1000);
  });
}

