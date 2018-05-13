import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { Observable } from 'rxjs/Observable';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { Console } from '@angular/core/src/console';

import { Indicator, IndicatorFormReferenceData, SelectList } from './indicator';

@Injectable()
export class IndicatorsService {
    API_URL: string;
    constructor(private httpClient: HttpClient) {
        this.API_URL = 'http://localhost:8749/api';
    }

    
    getIndicator(code: string) : Observable<Indicator> {
        if (code != null){
            return this.httpClient.get<Indicator>(
                this.API_URL + '/indicators/' + code);
        }
        else{
            let indicator: Indicator = {
                id: '',
                name: '',
                description: '',
                code: '',
                unit: '',
                periodicityTypeId: null,
                comparisonTypeId: null,
                indicatorValueTypeId: null
            };

            return  new Observable<Indicator>(observer => {
                observer.next(indicator);
                observer.complete();
            });
        }
    }

    createIndicator(indicator: Indicator): string {
        let location = '';
        this.httpClient
            .post(this.API_URL + '/indicators', indicator)
            .map((response: Response) => 
                response.headers.has('location') 
                    ? location = response.headers.get('location') 
                    : Observable.throw('Location header not present'))
            .subscribe((error:ErrorObservable) => console.log(error.error.status));
        
        return location;
    }

    getIndicatorReferenceData() : Observable<IndicatorFormReferenceData> {
        let pTypes: SelectList[] = [
            { id: 1, name: "1 Month"},
            { id: 2, name: "2 Months"},
            { id: 3, name: "3 Months"}
        ];

        let cTypes: SelectList[] = [
            { id: 1, name: "Greater than"},
            { id: 2, name: "Smaller than"},
            { id: 3, name: "Equal"}
        ]

        let iTypes: SelectList[] = [
            { id: 1, name: "Integer" }
        ]
        
        var data:  IndicatorFormReferenceData = { 
            periodicityTypes: pTypes,
            comparisonTypes: cTypes,
            indicatorValueTypes: iTypes
        };

        return new Observable<IndicatorFormReferenceData>(observer => {
            observer.next(data);
            observer.complete();
        });
    }
}