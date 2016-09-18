import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { IndicatorService } from './indicator.service';
import { Indicator } from './indicator';

@Component({
    selector: 'indicator-list',
    templateUrl: 'src/indicators/indicator.list.component.html',
    providers: [IndicatorService]
})
export class IndicatorListComponent implements OnInit {
    errorMessage: string;
    indicators: Indicator[];
    selectedIndicator: Indicator;

    constructor (
        private router: Router,
        private indicatorService: IndicatorService){
            this.selectedIndicator = null;
    }
    
    ngOnInit(): void {
        this.indicatorService.getIndicators()
            .subscribe(
                    indicators => this.indicators = indicators,
                    error =>  this.errorMessage = <any>error);
    }

    navigateToDetails(indicator: Indicator): void {
        this.router.navigate(['/indicator', indicator.code]);
    }

    showAddIndicatorMeasureForm(indicator: Indicator): void {
        this.selectedIndicator = indicator;
    }

    clearAddIndicatorMeasureForm(): void {
        this.selectedIndicator = null;
    }
}