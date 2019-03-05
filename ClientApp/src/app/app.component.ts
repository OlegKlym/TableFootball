import { Component } from '@angular/core';
import { DataService } from 'app/services/data.service';

@Component({
    selector: 'app-root',
    template: '<router-outlet></router-outlet>',
    providers: [DataService]
})

export class AppComponent {}