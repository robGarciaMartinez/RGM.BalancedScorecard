import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs/Observable';

import { IndicatorsService } from './indicators.service';
import { Indicator } from './indicator'

@Component({
    selector:'indicator',
    templateUrl: './indicator.template.html'
})
export class IndicatorComponent implements OnInit{
    indicator$: Observable<Indicator>;

    constructor(private indicatorsService: IndicatorsService) {
        this.indicator$ = this.indicatorsService.getIndicator('');
    }

    ngOnInit() {
        
    }

    saveIndicator(indicator: Indicator) {
        this.indicatorsService.saveIndicator(indicator);
    }
}