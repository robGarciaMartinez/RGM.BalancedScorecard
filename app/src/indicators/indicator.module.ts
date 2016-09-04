import { NgModule } from '@angular/core';
import { IndicatorListComponent } from './indicator.list.component'
import { IndicatorDetailsComponent } from './indicator.details.component'

@NgModule({
    declarations : [
        IndicatorListComponent,
        IndicatorDetailsComponent
    ],
    exports: [ 
        IndicatorListComponent 
    ],
})
export class IndicatorModule { }