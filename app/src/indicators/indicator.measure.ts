export class IndicatorMeasure {
    id: string;
    indicatorId: string;
    date: Date;
    record: any;
    objective: any;
    notes: string;

    constructor(){
        this.record = new SingleValue();
        this.objective = new SingleValue();
    }
}

class SingleValue {
    value: any;
}