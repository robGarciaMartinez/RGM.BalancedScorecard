import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';

import { IndicatorListComponent } from './indicator.list.component'
import { IndicatorDetailsComponent } from './indicator.details.component'

@NgModule({
    imports:[
        BrowserModule
    ],
    declarations : [
        IndicatorListComponent,
        IndicatorDetailsComponent
    ],
    exports: [ 
        IndicatorListComponent 
    ],
})
export class IndicatorModule { }