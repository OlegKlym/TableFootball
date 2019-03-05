import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GameCalibrationComponent } from './game-calibration.component';

const routes = [
  {
    path: 'game-calibration',
    component: GameCalibrationComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule],
  exports: [GameCalibrationComponent],
  declarations: [GameCalibrationComponent],
  bootstrap: [GameCalibrationComponent]
})
export class GameCalibrationModule { }