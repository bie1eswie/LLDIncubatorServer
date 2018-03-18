var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { Dashboard1Component } from "./dashboard1.component";
import { Dashboard2Component } from "./dashboard2.component";
import { Dashboard3Component } from "./dashboard3.component";
import { Dashboard4Component } from "./dashboard4.component";
import { Dashboard41Component } from "./dashboard41.component";
import { Dashboard5Component } from "./dashboard5.component";
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { FlotModule } from '../../components/charts/flotChart';
import { IboxtoolsModule } from '../../components/common/iboxtools/iboxtools.module';
import { PeityModule } from '../../components/charts/peity';
import { SparklineModule } from '../../components/charts/sparkline';
import { JVectorMapModule } from '../../components/map/jvectorMap';
var DashboardsModule = (function () {
    function DashboardsModule() {
    }
    return DashboardsModule;
}());
DashboardsModule = __decorate([
    NgModule({
        declarations: [Dashboard1Component, Dashboard2Component, Dashboard3Component, Dashboard4Component, Dashboard41Component, Dashboard5Component],
        imports: [BrowserModule, ChartsModule, FlotModule, IboxtoolsModule, PeityModule, SparklineModule, JVectorMapModule],
        exports: [Dashboard1Component, Dashboard2Component, Dashboard3Component, Dashboard4Component, Dashboard41Component, Dashboard5Component],
    })
], DashboardsModule);
export { DashboardsModule };
//# sourceMappingURL=dashboards.module.js.map