import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule }   from '@angular/router';
import { HomeComponent } from './home/home.component';
import { IndicatorListComponent } from './indicators/indicator.list.component';
import { IndicatorDetailsComponent } from './indicators/indicator.details.component';

const appRoutes : Routes = 
[
    {
        path : '',
        component : HomeComponent
    },
    {
        path : 'indicators',
        component : IndicatorListComponent
    },
    {
        path : 'indicator/:code',
        component : IndicatorDetailsComponent
    }
];

export const appRoutingProviders: any[] = [];
export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);