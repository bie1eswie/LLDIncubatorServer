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
import { Registration } from '../account/registration';
import { OperationResult } from '../../utilities/operationResult';
import { MembershipService } from '../../services/membership.service';
import { NotificationService } from '../../services/notification.service';
var SignUpComponent = (function () {
    function SignUpComponent(membershipService, notificationService, router) {
        this.membershipService = membershipService;
        this.notificationService = notificationService;
        this.router = router;
    }
    SignUpComponent.prototype.ngOnInit = function () {
        this._newUser = new Registration('', '', '', '');
    };
    SignUpComponent.prototype.register = function () {
        var _this = this;
        var _registrationResult = new OperationResult(false, '');
        this.membershipService.register(this._newUser)
            .subscribe(function (res) {
            _registrationResult.Succeeded = res.Succeeded;
            _registrationResult.Message = res.Message;
        }, function (error) { return console.error('Error: ' + error); }, function () {
            if (_registrationResult.Succeeded) {
                _this.notificationService.printSuccessMessage('Dear ' + _this._newUser.Username + ', please login with your credentials');
                _this.router.navigate(['/login']);
            }
            else {
                _this.notificationService.printErrorMessage(_registrationResult.Message);
            }
        });
    };
    ;
    return SignUpComponent;
}());
SignUpComponent = __decorate([
    Component({
        selector: 'signup',
        templateUrl: 'signup.component.html'
    }),
    __metadata("design:paramtypes", [MembershipService,
        NotificationService,
        Router])
], SignUpComponent);
export { SignUpComponent };
//# sourceMappingURL=signup.component.js.map