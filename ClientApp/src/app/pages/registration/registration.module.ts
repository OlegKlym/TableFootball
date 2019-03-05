import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { RegistrationComponent } from './registration.component';

@NgModule({
    imports: [FormsModule, CommonModule],
    exports: [RegistrationComponent],
    declarations: [RegistrationComponent],
    bootstrap: [RegistrationComponent]
})
export class RegistrationModule { }