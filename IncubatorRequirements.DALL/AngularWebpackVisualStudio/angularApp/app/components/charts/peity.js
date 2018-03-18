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
import './peity';
var PeityDirective = (function () {
    function PeityDirective(element) {
        this.initFlag = false;
        this.element = element;
    }
    PeityDirective.prototype.ngOnInit = function () {
        this.initFlag = true;
        if (this.options || this.type) {
            this.build();
        }
    };
    PeityDirective.prototype.build = function () {
        if (typeof jQuery(this.element).peity === 'undefined') {
            throw new Error('Configuration issue: Embedding peity lib is mandatory');
        }
        this.chart = jQuery(this.element.nativeElement).peity(this.type, this.options);
    };
    PeityDirective.prototype.ngOnChanges = function () {
        if (this.initFlag) {
            this.build();
        }
    };
    return PeityDirective;
}());
__decorate([
    Input(),
    __metadata("design:type", Object)
], PeityDirective.prototype, "options", void 0);
__decorate([
    Input(),
    __metadata("design:type", Object)
], PeityDirective.prototype, "type", void 0);
PeityDirective = __decorate([
    Directive({
        selector: 'span[peity]',
        exportAs: 'peity-chart',
    }),
    __metadata("design:paramtypes", [ElementRef])
], PeityDirective);
export { PeityDirective };
var PeityModule = (function () {
    function PeityModule() {
    }
    return PeityModule;
}());
PeityModule = __decorate([
    NgModule({
        declarations: [
            PeityDirective
        ],
        exports: [
            PeityDirective
        ],
        imports: []
    })
], PeityModule);
export { PeityModule };
//# sourceMappingURL=peity.js.map