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
var SparklineDirective = (function () {
    function SparklineDirective(element) {
        this.initFlag = false;
        this.element = element.nativeElement;
    }
    SparklineDirective.prototype.ngOnInit = function () {
        this.initFlag = true;
        if (this.options || this.datasets) {
            this.build();
        }
    };
    SparklineDirective.prototype.build = function () {
        if (typeof jQuery(this.element).sparkline() === 'undefined') {
            throw new Error('Configuration issue: Embedding sparkline lib is mandatory');
        }
        this.chart = jQuery(this.element).sparkline(this.datasets, this.options);
    };
    SparklineDirective.prototype.ngOnChanges = function () {
        if (this.initFlag) {
            this.build();
        }
    };
    return SparklineDirective;
}());
__decorate([
    Input(),
    __metadata("design:type", Object)
], SparklineDirective.prototype, "options", void 0);
__decorate([
    Input(),
    __metadata("design:type", Object)
], SparklineDirective.prototype, "datasets", void 0);
SparklineDirective = __decorate([
    Directive({
        selector: 'span[sparkline]',
        exportAs: 'sparkline-chart',
    }),
    __metadata("design:paramtypes", [ElementRef])
], SparklineDirective);
export { SparklineDirective };
var SparklineModule = (function () {
    function SparklineModule() {
    }
    return SparklineModule;
}());
SparklineModule = __decorate([
    NgModule({
        declarations: [
            SparklineDirective
        ],
        exports: [
            SparklineDirective
        ],
        imports: []
    })
], SparklineModule);
export { SparklineModule };
//# sourceMappingURL=sparkline.js.map