import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { IndicatorService } from './indicator.service';
import { Indicator } from './indicator'

@Component({
    selector: 'indicator-details',
    templateUrl: 'html/indicators/indicator.details.component.html',
    providers: [IndicatorService]
})
export class IndicatorDetailsComponent implements OnInit {
    errorMessage: string;
    indicator: Indicator;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private indicatorsService : IndicatorService){} 

    ngOnInit(): void {
        let code = this.route.snapshot.params['code'];
        this.indicatorsService.getIndicator(code).subscribe(
            indicator => this.indicator = indicator
        );       
    }
}