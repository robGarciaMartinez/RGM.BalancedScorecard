import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs/Observable';

import { IndicatorsService } from './indicators.service';
import { Indicator, IndicatorFormReferenceData } from './indicator'
import { ActivatedRoute } from '@angular/router';

@Component({
    selector:'indicator',
    templateUrl: './indicator.template.html'
})
export class IndicatorComponent implements OnInit{
    indicator$: Observable<Indicator>;
    indicatorReferenceData$: Observable<IndicatorFormReferenceData>;
    indicatorCode: string;

    constructor(
        private indicatorsService: IndicatorsService,
        private route: ActivatedRoute) 
    {       
        this.route.queryParams.subscribe(params => {
            this.indicatorCode = params['code'];
        });
        
        this.indicator$ = this.indicatorsService.getIndicator(this.indicatorCode); 
        this.indicatorReferenceData$ = this.indicatorsService.getIndicatorReferenceData();
    }

    ngOnInit() {
        
    }

    saveIndicator(indicator: Indicator) {
        this.indicatorsService.createIndicator(indicator);
    }
}