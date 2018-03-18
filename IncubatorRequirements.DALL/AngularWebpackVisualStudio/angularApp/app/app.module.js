var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from "@angular/router";
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { ROUTES } from "./app.routes";
import { DashboardsModule } from "./views/dashboards/dashboards.module";
import { AppviewsModule } from "./views/appviews/appviews.module";
import { AppComponent } from './app.component';
import { LayoutsModule } from "./components/common/layouts/layouts.module";
import { DataService } from './services/data.service';
import { MembershipService } from './services/membership.service';
import { UtilityService } from './services/utility.service';
import { NotificationService } from './services/notification.service';
var AppModule = (function () {
    function AppModule() {
    }
    return AppModule;
}());
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent
        ],
        imports: [
            BrowserModule,
            FormsModule,
            HttpModule,
            DashboardsModule,
            LayoutsModule,
            AppviewsModule,
            RouterModule.forRoot(ROUTES)
        ],
        providers: [DataService, MembershipService, UtilityService, NotificationService,
            { provide: LocationStrategy, useClass: HashLocationStrategy }],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map