import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes} from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule }   from '@angular/common/http';
import { AvatarModule } from 'ngx-avatar';

import { AppComponent } from './app.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { RatingComponent } from './pages/ratings/rating.component';

const appRoutes: Routes = [
    {
        path: 'registration',
        component: RegistrationComponent
    },
    {
        path: 'game',
        loadChildren: './pages/game/game.module#GameModule'
    },
    {
        path: '**',
        component: RatingComponent
    },
];

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpClientModule,
        AvatarModule,
        RouterModule.forRoot(appRoutes)
    ],
    declarations: [
        AppComponent,
        RegistrationComponent,
        RatingComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }