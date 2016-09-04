import { Injectable } from '@angular/core';
import { Indicator } from './indicator';
import { Indicators } from './indicator.mock';

@Injectable()
export class IndicatorService{
    getIndicators() : Indicator[] {
        return Indicators;
    }
}