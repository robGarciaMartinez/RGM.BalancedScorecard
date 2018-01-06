import { Component, Input, Output, ChangeDetectionStrategy, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';

import { Indicator } from './indicator';

@Component({
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector:'indicator-form',
    templateUrl: './indicator-form.template.html'
})
export class IndicatorFormComponent {
    indicatorForm: FormGroup;

    @Input() set model(value: Indicator) {
        if (value == null) {
            return;
        }

        this.indicatorForm.patchValue({
          'name': value.name,
          'code': value.code,
          'description': value.description
        });
    }

    @Output()
    saveClicked = new EventEmitter<Indicator>();
    
    constructor(private fb: FormBuilder) {
        this.indicatorForm = this.fb.group({
            'name':[null, Validators.required],
            'code':[null, Validators.required],
            'description':[null, Validators.required]
        });
    }

    saveIndicator(form){
        var indicator = new Indicator();
        indicator.name = form.name;
        indicator.code = form.code;
        indicator.description = form.description;

        this.saveClicked.emit(indicator);
    }
}