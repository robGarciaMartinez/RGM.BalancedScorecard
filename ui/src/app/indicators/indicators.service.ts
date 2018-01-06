import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { Indicator } from 'src/app/indicators/indicator';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class IndicatorsService {
    constructor(private httpClient: HttpClient) {
    }

    getIndicator(code: string) : Observable<Indicator> {
        return this.httpClient.get<Indicator>(
            'http://localhost:63530/api/indicators', 
            { params: new HttpParams().set('code', code) });
    }

    saveIndicator(indicator: Indicator) {
        this.httpClient.post('http://localhost:63530/api/indicators', indicator).subscribe();
    }
}