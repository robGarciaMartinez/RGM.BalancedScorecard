import { Component, OnInit } from '@angular/core';
import { IndicatorService } from './indicator.service';
import { Indicator } from './indicator'

@Component({
    selector : 'indicator-list',
    template : '<div>Indicator list</div>',
    providers: [IndicatorService]
})
export class IndicatorListComponent implements OnInit {
    indicators : Indicator[];
    constructor(private indicatorService: IndicatorService){}
    
    ngOnInit() : void {
        this.indicators = this.indicatorService.getIndicators();
    }
}