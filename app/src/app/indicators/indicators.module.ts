import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { NewIndicator } from './new-indicator.component';

export const routes = [
  { path: '', component: NewIndicator, pathMatch: 'full' }
];

@NgModule({
  declarations: [
    NewIndicator
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild(routes),
  ]
})
export class IndicatorsModule {
  static routes = routes;
}
