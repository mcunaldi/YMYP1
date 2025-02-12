import { Routes } from '@angular/router';
import { LayoutsComponent } from './components/layouts/layouts.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';
import { PrintComponent } from './components/print/print.component';

export const routes: Routes = [
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "print/:value",
        component: PrintComponent
    },
    {
        path: "",
        component: LayoutsComponent,
        canActivateChild: [()=> inject(AuthService).isAuthenticated()],
        children: [
            {
                path: "",
                component: HomeComponent
            }
        ]
    }
];
