import { Component } from '@angular/core';

@Component({
  selector: 'QuestionCandidat',
  templateUrl: './quizz-question.component.html',
  styleUrls: ['./quizz-question.component.css']
})
export class QuestionCandidat {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
