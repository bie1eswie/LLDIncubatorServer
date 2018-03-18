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
import { User } from '../account/user';
import { OperationResult } from '../../utilities/operationResult';
import { MembershipService } from '../../services/membership.service';
import { NotificationService } from '../../services/notification.service';
var LoginComponent = (function () {
    function LoginComponent(membershipService, notificationService, router) {
        this.membershipService = membershipService;
        this.notificationService = notificationService;
        this.router = router;
    }
    LoginComponent.prototype.ngOnInit = function () {
        this._user = new User('', '');
    };
    LoginComponent.prototype.login = function () {
        var _this = this;
        var _authenticationResult = new OperationResult(false, '');
        this.membershipService.login(this._user)
            .subscribe(function (res) {
            _authenticationResult.Succeeded = res.Succeeded;
            _authenticationResult.Message = res.Message;
        }, function (error) { return console.error('Error: ' + error); }, function () {
            if (_authenticationResult.Succeeded) {
                _this.notificationService.printSuccessMessage('Welcome back ' + _this._user.Username + '!');
                localStorage.setItem('user', JSON.stringify(_this._user));
                _this.router.navigate(['home']);
            }
            else {
                _this.notificationService.printErrorMessage(_authenticationResult.Message);
            }
        });
    };
    ;
    return LoginComponent;
}());
LoginComponent = __decorate([
    Component({
        selector: 'login',
        templateUrl: 'login.template.html'
    }),
    __metadata("design:paramtypes", [MembershipService,
        NotificationService,
        Router])
], LoginComponent);
export { LoginComponent };
//# sourceMappingURL=login.component.js.map