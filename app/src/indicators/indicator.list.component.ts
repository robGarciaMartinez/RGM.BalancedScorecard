import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

import { IndicatorService } from './indicator.service';
import { Indicator } from './indicator'

@Component({
    selector: 'indicator-list',
    templateUrl: 'src/indicators/indicator.list.component.html',
    providers: [IndicatorService]
})
export class IndicatorListComponent implements OnInit {
    errorMessage: string;
    indicators: Indicator[];
    
    constructor(
        private router: Router,
        private indicatorService: IndicatorService){}
    
    ngOnInit(): void {
        this.indicatorService.getIndicators()
            .subscribe(
                    indicators => this.indicators = indicators,
                    error =>  this.errorMessage = <any>error);
    }

    navigateToDetails(indicator: Indicator): void{
        this.router.navigate(['/indicator', indicator.code]);
    }
}