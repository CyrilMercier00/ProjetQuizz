import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-generate-niveau',
  templateUrl: './generate-niveau.component.html',
  styleUrls: ['./generate-niveau.component.css']
})
export class GenerateNiveauComponent implements OnInit {

  niveauForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.niveauForm=this.fb.group({})
   }

  ngOnInit(): void {
  }

}
