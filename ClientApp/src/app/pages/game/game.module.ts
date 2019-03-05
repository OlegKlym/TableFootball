import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { GameConfigurationModule } from './game-configuration/game-configuration.module';
import { GameCalibrationModule } from './game-calibration/game-calibration.module';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        GameConfigurationModule,
        GameCalibrationModule
    ]
})
export class GameModule { }