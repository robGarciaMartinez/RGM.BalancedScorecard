import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { IndicatorComponent } from './indicator.component';
import { IndicatorFormComponent } from './indicator-form.component';
import { IndicatorsService } from './indicators.service';
import { ROUTES } from './indicator.routes';
import { IndicatorListComponent } from './indicator-list.component';


@NgModule({
  declarations: [
    IndicatorComponent,
    IndicatorFormComponent,
    IndicatorListComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    ROUTES,
  ],
  providers: [IndicatorsService, HttpClientModule]
})
export class IndicatorsModule {
}