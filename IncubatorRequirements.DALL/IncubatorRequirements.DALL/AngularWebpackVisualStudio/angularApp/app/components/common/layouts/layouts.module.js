var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { BsDropdownModule } from 'ngx-bootstrap';
import { BasicLayoutComponent } from "./basicLayout.component";
import { BlankLayoutComponent } from "./blankLayout.component";
import { TopNavigationLayoutComponent } from "./topNavigationlayout.component";
import { NavigationComponent } from "./../navigation/navigation.component";
import { FooterComponent } from "./../footer/footer.component";
import { TopNavbarComponent } from "./../topnavbar/topnavbar.component";
import { TopNavigationNavbarComponent } from "./../topnavbar/topnavigationnavbar.component";
var LayoutsModule = (function () {
    function LayoutsModule() {
    }
    return LayoutsModule;
}());
LayoutsModule = __decorate([
    NgModule({
        declarations: [
            FooterComponent,
            BasicLayoutComponent,
            BlankLayoutComponent,
            NavigationComponent,
            TopNavigationLayoutComponent,
            TopNavbarComponent,
            TopNavigationNavbarComponent
        ],
        imports: [
            BrowserModule,
            RouterModule,
            BsDropdownModule.forRoot()
        ],
        exports: [
            FooterComponent,
            BasicLayoutComponent,
            BlankLayoutComponent,
            NavigationComponent,
            TopNavigationLayoutComponent,
            TopNavbarComponent,
            TopNavigationNavbarComponent
        ],
    })
], LayoutsModule);
export { LayoutsModule };
//# sourceMappingURL=layouts.module.js.map