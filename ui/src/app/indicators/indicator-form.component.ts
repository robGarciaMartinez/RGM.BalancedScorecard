import { Component, Input, Output, ChangeDetectionStrategy, EventEmitter, OnInit } from '@angular/core';
import { FormsModule, FormControl, AbstractControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, ParamMap } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { Indicator, IndicatorFormReferenceData } from './indicator';


@Component({
    changeDetection: ChangeDetectionStrategy.OnPush,
    selector:'indicator-form',
    templateUrl: './indicator-form.template.html'
})
export class IndicatorFormComponent implements OnInit {
    indicatorForm: FormGroup;
    indicator:Indicator;
    indicatorReferenceData: IndicatorFormReferenceData;
    attemptToSaveInvalidForm: boolean;

    constructor(private router: Router){
    }

    ngOnInit(){
        this.indicatorForm = new FormGroup ({
            name: new FormControl('', Validators.required),
            description: new FormControl('', Validators.required),
            code: new FormControl('', Validators.required),
            unit: new FormControl('', Validators.required),
            periodicityTypeId: new FormControl('', Validators.required),
            comparisonTypeId: new FormControl('', Validators.required),
            indicatorValueTypeId: new FormControl('', Validators.required)
        });
    }

    @Input() set model(value: Indicator) {
        if (value == null) {
            return;
        }

        if (this.indicatorForm == null){
            return;
        }
        
        this.indicatorForm.patchValue(value);
    }
    @Input() set referenceData(value: IndicatorFormReferenceData) {
        if (value == null) {
            return;
        }

        this.indicatorReferenceData = value;
    }

    @Output() saveClicked = new EventEmitter<Indicator>();
    @Output() cancelled = new EventEmitter<any>();

    saveIndicator(indicatorForm: FormGroup) {
        if (indicatorForm.valid){
            this.saveClicked.emit(<Indicator>indicatorForm.value);
        }
        else{
            this.attemptToSaveInvalidForm = true;
        }
    }

    cancel() {
        this.cancelled.emit(null);
    }

    hasErrors(control: AbstractControl) : boolean {
        return control.errors != null;
    }

    isTouched(control: AbstractControl) : boolean {
        return control.touched  || this.attemptToSaveInvalidForm;
    }
}