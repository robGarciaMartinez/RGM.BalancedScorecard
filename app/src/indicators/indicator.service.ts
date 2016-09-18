import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';

import { Observable }     from 'rxjs/Observable';

import { Indicator } from './indicator';

@Injectable()
export class IndicatorService {
    constructor (private http: Http) {}

    getIndicators() : Observable<Indicator[]> {
        let page = 1;
        return this.http.get(`http://localhost:55004/api/indicators?page=${page}`)
                        .map(this.extractData)
                        .catch(this.handleError);
    }

    getIndicator(code: string) : Observable<Indicator> {
        return this.http.get(`http://localhost:55004/api/indicators/${code}`)
                        .map(this.extractData)
                        .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || { };
    }

    private handleError (error: any) {
        // In a real world app, we might use a remote logging infrastructure
        // We'd also dig deeper into the error to get a better message
        let errMsg = (error.message) ? error.message :
        error.status ? `${error.status} - ${error.statusText}` : 'Server error';
        console.error(errMsg); // log to console instead
        return Observable.throw(errMsg);
    }
}