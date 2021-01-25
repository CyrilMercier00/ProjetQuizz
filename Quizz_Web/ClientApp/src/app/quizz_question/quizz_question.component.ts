import { Component } from '@angular/core';

@Component({
  selector: 'quizz_question',
  templateUrl: './quizz_question.component.html',
  styleUrls: ['./quizz_question.component.css']
})

export class QuizzQuestionComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
