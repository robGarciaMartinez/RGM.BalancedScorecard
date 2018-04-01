import { Component, Input, Output, ChangeDetectionStrategy, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Observable } from 'rxjs/Observable';

import { Indicator } from './indicator';
import { AbstractControl } from '@angular/forms/src/model';

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
        this.indicatorForm = this.buildForm(fb);
    }

    saveIndicator(indicatorForm: FormGroup) {
        this.saveClicked.emit(<Indicator>indicatorForm.value);
    }

    buildForm(fb: FormBuilder) : FormGroup {
        return this.fb.group({
            'name':[null, Validators.required],
            'description':[null, Validators.required],
            'code':[null, Validators.required],
            'unit': [null, Validators.required],
            'periodicityType': [null, Validators.required],
            'comparisonType': [null, Validators.required],
            'indicatorValueType': [null, Validators.required],
        });
    }

    hasErrors(control: AbstractControl) : boolean {
        return control.errors != null;
    }

    isTouched(control: AbstractControl) : boolean {
        return control.touched;
    }
}