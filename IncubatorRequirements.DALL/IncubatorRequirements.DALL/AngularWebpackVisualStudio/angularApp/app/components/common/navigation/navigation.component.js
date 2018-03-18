var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import 'jquery-slimscroll';
var NavigationComponent = (function () {
    function NavigationComponent(router) {
        this.router = router;
    }
    NavigationComponent.prototype.ngAfterViewInit = function () {
        jQuery('#side-menu').metisMenu();
        if (jQuery("body").hasClass('fixed-sidebar')) {
            jQuery('.sidebar-collapse').slimscroll({
                height: '100%'
            });
        }
    };
    NavigationComponent.prototype.activeRoute = function (routename) {
        return this.router.url.indexOf(routename) > -1;
    };
    return NavigationComponent;
}());
NavigationComponent = __decorate([
    Component({
        selector: 'navigation',
        templateUrl: 'navigation.template.html'
    }),
    __metadata("design:paramtypes", [Router])
], NavigationComponent);
export { NavigationComponent };
//# sourceMappingURL=navigation.component.js.map