import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { IndicatorComponent } from './indicator.component';
import { IndicatorFormComponent } from './indicator-form.component';
import { IndicatorsService } from './indicators.service';

export const routes = [
  { path: '', component: IndicatorComponent, pathMatch: 'full' }
];

@NgModule({
  declarations: [
    IndicatorComponent,
    IndicatorFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forChild(routes),
  ],
  providers: [IndicatorsService, HttpClientModule]
})
export class IndicatorsModule {
  static routes = routes;
}