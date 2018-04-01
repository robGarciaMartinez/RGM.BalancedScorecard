export class Indicator {
    name: string;
    description:string;
    code: string;
    unit: string;
    periodicityType: number;
    comparisonType: number;
    indicatorValueType: number;

    constructor(
        name: string, 
        description: string,
        code: string,
        unit: string,
        periodicityType: number,
        comparisonType: number,
        indicatorValueType: number
    )
    {
        this.name = name;
        this.description = description;
        this.code = code;
        this.unit = unit;
        this.periodicityType = periodicityType;
        this.comparisonType = comparisonType;
        this.indicatorValueType = indicatorValueType;
    }
}