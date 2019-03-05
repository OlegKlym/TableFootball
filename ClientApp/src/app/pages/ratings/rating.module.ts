import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RatingComponent } from './rating.component';


@NgModule({
  imports: [FormsModule, CommonModule],
  exports: [RatingComponent],
  declarations: [RatingComponent],
  bootstrap: [RatingComponent]
})
export class RatingModule { }