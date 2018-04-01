import { Injectable } from '@angular/core'
import { HttpClient, HttpParams } from '@angular/common/http'
import { Indicator } from './indicator';
import { Observable } from 'rxjs/Observable';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';
import { Console } from '@angular/core/src/console';

@Injectable()
export class IndicatorsService {
    constructor(private httpClient: HttpClient) {
    }

    getIndicator(code: string) : Observable<Indicator> {
        return this.httpClient.get<Indicator>(
            process.env.API_URL + '/indicators/0');
    }

    createIndicator(indicator: Indicator): string {
        let location = '';
        this.httpClient
            .post(process.env.API_URL + '/indicators', indicator)
            .map((response: Response) => 
                response.headers.has('location') 
                    ? location = response.headers.get('location') 
                    : Observable.throw('Location header not present'))
            .subscribe((error:ErrorObservable) => console.log(error.error.status));
        
        return location;
    }
}