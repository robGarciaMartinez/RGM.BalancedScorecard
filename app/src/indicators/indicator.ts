import { IndicatorMeasure } from './indicator.measure'

export class Indicator {
    id: string;
    code: string;
    name: string;
    description: string;
    startDate: Date;
    unit: string;
    periodicity: number;
    comparisonValue: number;
    objectiveValue: number;
    indicatorTypeId: string;
    responsibleId: string;
    fulfillmentRate: number;
    cumulative: boolean;
    state: number;
    lastMeasureDate: Date;
    measures: IndicatorMeasure[]
}