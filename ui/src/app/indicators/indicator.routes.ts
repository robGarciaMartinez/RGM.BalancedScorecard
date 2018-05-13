import { Routes, RouterModule }  from '@angular/router';
import { IndicatorListComponent } from './indicator-list.component';
import { IndicatorComponent } from './indicator.component';

const routes : Routes =
[
    { path:'', component: IndicatorListComponent, pathMatch: 'full' },
    { path:'new', component: IndicatorComponent },
    { path:'edit/:code', component: IndicatorComponent }
];

export const ROUTES = RouterModule.forChild(routes);