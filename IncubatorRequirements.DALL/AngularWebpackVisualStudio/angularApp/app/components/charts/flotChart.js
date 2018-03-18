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
import './../../../vendor/flot/jquery.flot.js';
import './../../../vendor/flot/jquery.flot.tooltip.min.js';
import './../../../vendor/flot/jquery.flot.spline.js';
import './../../../vendor/flot/jquery.flot.time.js';
var FlotChartDirective = (function () {
    function FlotChartDirective(element) {
        this.initFlag = false;
        this.element = element;
    }
    FlotChartDirective.prototype.ngOnInit = function () {
        this.initFlag = true;
        if (this.options || this.dataset) {
            this.build();
        }
    };
    FlotChartDirective.prototype.build = function () {
        this.ngOnDestroy();
        if (typeof jQuery.plot === 'undefined') {
            throw new Error('Configuration issue: Embedding jquery.flot.js lib is mandatory');
        }
        this.chart = jQuery.plot(this.element.nativeElement, this.dataset, this.options);
    };
    FlotChartDirective.prototype.ngOnChanges = function (changes) {
        if (this.initFlag) {
            if (changes.hasOwnProperty('dataset')) {
                this.updateChartData(changes['dataset'].currentValue);
            }
            else {
                this.build();
            }
        }
    };
    FlotChartDirective.prototype.updateChartData = function (newDataValues) {
        this.chart.setData(newDataValues);
        this.chart.setupGrid();
        this.chart.draw();
    };
    FlotChartDirective.prototype.ngOnDestroy = function () {
        if (this.chart) {
            this.chart.shutdown();
            this.chart = void 0;
        }
    };
    FlotChartDirective.prototype.onResize = function () {
        this.chart.resize();
        this.chart.setupGrid();
        this.chart.draw();
    };
    return FlotChartDirective;
}());
__decorate([
    Input(),
    __metadata("design:type", Object)
], FlotChartDirective.prototype, "options", void 0);
__decorate([
    Input(),
    __metadata("design:type", Object)
], FlotChartDirective.prototype, "dataset", void 0);
FlotChartDirective = __decorate([
    Directive({
        selector: 'div[flotChart]',
        exportAs: 'flot-chart',
        host: {
            '(window:resize)': 'onResize()'
        }
    }),
    __metadata("design:paramtypes", [ElementRef])
], FlotChartDirective);
export { FlotChartDirective };
var FlotModule = (function () {
    function FlotModule() {
    }
    return FlotModule;
}());
FlotModule = __decorate([
    NgModule({
        declarations: [
            FlotChartDirective
        ],
        exports: [
            FlotChartDirective
        ],
        imports: []
    })
], FlotModule);
export { FlotModule };
//# sourceMappingURL=flotChart.js.map