import { NgModule } from '@angular/core';
import { BrowserModule }  from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { IndicatorListComponent } from './indicator.list.component';
import { IndicatorDetailsComponent } from './indicator.details.component';
import { AddIndicatorMeasureComponent } from './add.indicator.measure.component';

@NgModule({
    imports:[
        BrowserModule,
        FormsModule
    ],
    declarations : [
        IndicatorListComponent,
        IndicatorDetailsComponent,
        AddIndicatorMeasureComponent
    ],
    exports: [ 
        IndicatorListComponent 
    ],
})
export class IndicatorModule { }