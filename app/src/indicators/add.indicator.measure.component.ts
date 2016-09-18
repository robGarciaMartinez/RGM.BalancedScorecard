import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Indicator } from './indicator';
import { IndicatorMeasure } from './indicator.measure';
import { IndicatorService } from './indicator.service';

@Component({
    selector: 'add-indicator-measure',
    templateUrl: 'src/indicators/add.indicator.measure.component.html',
    providers: [IndicatorService]
})
export class AddIndicatorMeasureComponent{
    @Input() indicator: Indicator;
    @Output() indicatorMeasureSaved= new EventEmitter<any>();
    measure: IndicatorMeasure;
    errorMessage: string;
    
    constructor(private indicatorService: IndicatorService){
        this.measure = new IndicatorMeasure(); 
    }

    saveMeasure(): void {
        this.measure.id = new GUID().toString();
        this.indicatorService.saveIndicatorMeasure(this.indicator.id, this.measure)
            .subscribe(error =>  this.errorMessage = <any>error);
        this.indicatorMeasureSaved.emit();
    }
}

class GUID {
    private str: string;

    constructor(str?: string) {
        this.str = str || GUID.getNewGUIDString();
    }

    toString() {
        return this.str;
    }

    private static getNewGUIDString() {
        // your favourite guid generation function could go here
        // ex: http://stackoverflow.com/a/8809472/188246
        let d = new Date().getTime();
        if (window.performance && typeof window.performance.now === "function") {
            d += performance.now(); //use high-precision timer if available
        }
        return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, (c) => {
            let r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d/16);
            return (c=='x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
    }
}