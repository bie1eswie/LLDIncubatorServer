var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { ElementRef, Input, NgModule, Directive } from '@angular/core';
import './../../../../node_modules/jvectormap/jquery-jvectormap.min.js';
import './../../../../node_modules/jvectormap/tests/assets/jquery-jvectormap-world-mill-en.js';
var JVectorMapDirective = (function () {
    function JVectorMapDirective(element) {
        this.initFlag = false;
        this.element = element;
    }
    JVectorMapDirective.prototype.ngOnInit = function () {
        this.initFlag = true;
        if (this.options) {
            this.build();
        }
    };
    JVectorMapDirective.prototype.build = function () {
        this.ngOnDestroy();
        if (typeof jQuery(this.element.nativeElement).vectorMap === 'undefined') {
            throw new Error('Configuration issue: Embedding jvectormap lib is mandatory');
        }
        this.map = jQuery(this.element.nativeElement).vectorMap(this.options);
    };
    JVectorMapDirective.prototype.ngOnChanges = function (changes) {
        if (this.initFlag) {
            this.build();
        }
    };
    JVectorMapDirective.prototype.ngOnDestroy = function () {
        if (this.map) {
            this.map.remove();
        }
    };
    return JVectorMapDirective;
}());
__decorate([
    Input(),
    __metadata("design:type", Object)
], JVectorMapDirective.prototype, "options", void 0);
JVectorMapDirective = __decorate([
    Directive({
        selector: 'div[jvectormap]',
    }),
    __metadata("design:paramtypes", [ElementRef])
], JVectorMapDirective);
export { JVectorMapDirective };
var JVectorMapModule = (function () {
    function JVectorMapModule() {
    }
    return JVectorMapModule;
}());
JVectorMapModule = __decorate([
    NgModule({
        declarations: [
            JVectorMapDirective
        ],
        exports: [
            JVectorMapDirective
        ],
        imports: []
    })
], JVectorMapModule);
export { JVectorMapModule };
//# sourceMappingURL=jvectorMap.js.map