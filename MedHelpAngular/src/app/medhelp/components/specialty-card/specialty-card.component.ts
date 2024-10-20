import { Component, Input, OnInit } from '@angular/core';
import { Specialty } from '../../interfaces/specialty.interface';

@Component({
  selector: 'specialty-card',
  templateUrl: './specialty-card.component.html',
  styleUrl: './specialty-card.component.css'
})
export class CardComponent implements OnInit{


  @Input()
  public specialty?: Specialty;

  ngOnInit(): void {
    if ( !this.specialty ) throw Error('Specialty property is requiered');

  }



}
