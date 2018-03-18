var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { StarterViewComponent } from "./starterview.component";
import { LoginComponent } from "./login.component";
import { SignUpComponent } from "./signup.component";
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { PeityModule } from '../../components/charts/peity';
import { SparklineModule } from '../../components/charts/sparkline';
var AppviewsModule = (function () {
    function AppviewsModule() {
    }
    return AppviewsModule;
}());
AppviewsModule = __decorate([
    NgModule({
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
], AppviewsModule);
export { AppviewsModule };
//# sourceMappingURL=appviews.module.js.map