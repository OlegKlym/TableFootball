import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { GameConfigurationComponent } from './game-configuration.component';

const routes = [
  {
    path: 'game-configuration',
    component: GameConfigurationComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule
  ],
  exports: [GameConfigurationComponent],
  declarations: [GameConfigurationComponent],
  bootstrap: [GameConfigurationComponent]
})
export class GameConfigurationModule { }