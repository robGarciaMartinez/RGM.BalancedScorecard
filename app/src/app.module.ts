import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { IndicatorModule } from './indicators/indicator.module';
import { AppComponent } from './app.component';

@NgModule({
  imports: [
    BrowserModule,
    IndicatorModule
  ],
  declarations: [
    AppComponent
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule { }