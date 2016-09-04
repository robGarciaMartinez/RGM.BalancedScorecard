import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  template: '<h1>My First Angular 2 App {{message}}</h1><indicator-list></indicator-list>' 
})
export class AppComponent { 
  message = "I'm a cunt"
}