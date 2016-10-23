import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { IndicatorService } from './indicator.service';
import { Indicator } from './indicator';

@Component({
    selector: 'indicator-list',
    templateUrl: 'html/indicators/indicator.list.component.html',
    providers: [IndicatorService]
})
export class IndicatorListComponent implements OnInit {
    errorMessage: string;
    selectedIndicator: string;
    indicators: Indicator[];

    constructor (
        private router: Router,
        private indicatorService: IndicatorService){
            this.selectedIndicator = null;
    }
    
    ngOnInit(): void {
        this.indicatorService.getIndicators()
            .subscribe(
                    indicators => this.indicators = indicators,
                    error => this.errorMessage = <any>error);
    }

    navigateToDetails(indicator: Indicator): void {
        this.router.navigate(['/indicator', indicator.code]);
    }

    showHideFormEvent(indicator: Indicator): void {
        this.selectedIndicator = this.selectedIndicator != indicator.id ? indicator.id : null;
    }

    showHideFormCondition(indicator: Indicator): boolean {
        return this.selectedIndicator == indicator.id;
    }

    showHideFormButtonText(indicator: Indicator): string {
        return this.selectedIndicator != indicator.id ? "Add period" : "Hide form";
    }

    clearAddIndicatorMeasureForm(): void {
        this.selectedIndicator = null;
    }
}