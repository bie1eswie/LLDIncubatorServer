import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";
import {RouterModule} from "@angular/router";

import {StarterViewComponent} from "./starterview.component";
import {LoginComponent} from "./login.component";
import {SignUpComponent} from "./signup.component";
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {PeityModule } from '../../components/charts/peity';
import {SparklineModule } from '../../components/charts/sparkline';
import { DataService } from '../../services/data.service';
import { MembershipService } from '../../services/membership.service';
import { UtilityService } from '../../services/utility.service';
import { NotificationService } from '../../services/notification.service';

@NgModule({
  declarations: [
    StarterViewComponent,
    LoginComponent,
    SignUpComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    PeityModule,
    SparklineModule,
    FormsModule,
    HttpModule,
  ],
  exports: [
    StarterViewComponent,
    LoginComponent,
    SignUpComponent
  ],
})

export class AppviewsModule {
}
