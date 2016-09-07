import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: '<h1>Balanced Scorecard</h1><nav><a routerLink="/" routerLinkActive="active">Home</a><a routerLink="/indicators">Indicators</a></nav><router-outlet></router-outlet>' 
})
export class AppComponent { 
}