import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';

import { IndicatorModule } from './indicators/indicator.module';
import { HomeModule } from './home/home.module';
import { AppComponent } from './app.component';
import { appRoutingProviders, routing } from './app.routing';

@NgModule({
  imports: [
    BrowserModule,
    IndicatorModule,
    HomeModule,
    HttpModule,
    JsonpModule,
    routing
  ],
  declarations: [
    AppComponent
  ],
  providers:[ 
    appRoutingProviders
  ],
  bootstrap: [ 
    AppComponent 
  ]
})
export class AppModule { }