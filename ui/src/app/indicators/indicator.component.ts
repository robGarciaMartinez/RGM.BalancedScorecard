import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs/Observable';

import { IndicatorsService } from './indicators.service';
import { Indicator, IndicatorFormReferenceData } from './indicator'
import { ActivatedRoute, Router } from '@angular/router';

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
        private route: ActivatedRoute, 
        private router: Router) 
    {       
        this.route.paramMap.subscribe(params => {
            this.indicatorCode = params.get('code');
        });
    }

    ngOnInit() {  
        this.indicator$ = this.indicatorsService.getIndicator(this.indicatorCode); 
        this.indicatorReferenceData$ = this.indicatorsService.getIndicatorReferenceData();
    }

    saveIndicator(indicator: Indicator) {
        this.indicatorsService.createIndicator(indicator);
        this.router.navigate(['./app/indicators/edit/' + indicator.code]);
    }

    cancel(){
        this.router.navigate(['./app/indicators']);
    }
}