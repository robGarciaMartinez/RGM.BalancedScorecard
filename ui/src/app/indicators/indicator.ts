export class Indicator {
    id: string;
    name: string;
    description:string;
    code: string;
    unit: string;
    periodicityTypeId: number;
    comparisonTypeId: number;
    indicatorValueTypeId: number;
}

export class IndicatorFormReferenceData {
    periodicityTypes: SelectList[];
    comparisonTypes: SelectList[];
    indicatorValueTypes: SelectList[];
}

export class SelectList{ 
    id: number;
    name: string
}