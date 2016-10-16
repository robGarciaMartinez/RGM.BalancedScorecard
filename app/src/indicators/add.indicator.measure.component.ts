import { Component, Input, Output, EventEmitter } from '@angular/core';

import { Indicator } from './indicator';
import { IndicatorMeasure } from './indicator.measure';
import { IndicatorService } from './indicator.service';

@Component({
    selector: 'add-indicator-measure',
    templateUrl: 'src/indicators/add.indicator.measure.component.html',
    providers: [IndicatorService]
})
export class AddIndicatorMeasureComponent {
    @Input() indicatorId: string;
    @Input() minDate: string;
    @Output() indicatorMeasureSaved = new EventEmitter<any>();
    measure: IndicatorMeasure;
    errorMessage: string;
    
    constructor(private indicatorService: IndicatorService){
        this.measure = new IndicatorMeasure();
    }

    saveMeasure(): void {
        this.indicatorService.saveIndicatorMeasure(this.indicatorId, this.measure)
            .subscribe(error =>  this.errorMessage = <any>error);
        this.indicatorMeasureSaved.emit();
    }
}