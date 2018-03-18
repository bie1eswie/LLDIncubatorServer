import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { RouterModule } from "@angular/router";
import { Location, LocationStrategy, HashLocationStrategy } from '@angular/common';

import { ROUTES } from "./app.routes";

// App views
import { DashboardsModule } from "./views/dashboards/dashboards.module";
import { AppviewsModule } from "./views/appviews/appviews.module";

import { Configuration } from './app.constants';

import { AppComponent } from './app.component';

// App modules/components
import { LayoutsModule } from "./components/common/layouts/layouts.module";

//services
import { DataService } from './services/data.service';
import { MembershipService } from './services/membership.service';
import { UtilityService } from './services/utility.service';
import { NotificationService } from './services/notification.service';

@NgModule({
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
export class AppModule { }
