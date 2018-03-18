var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Injectable } from '@angular/core';
import { DataService } from './data.service';
import { User } from '../views/account/user';
var MembershipService = (function () {
    function MembershipService(accountService) {
        this.accountService = accountService;
        this._accountRegisterAPI = 'http://localhost:63020/api/account/register/';
        this._accountLoginAPI = 'http://localhost:63020/api/values/authenticate/';
        this._accountLogoutAPI = 'http://localhost:63020/api/account/logout/';
    }
    MembershipService.prototype.register = function (newUser) {
        this.accountService.set(this._accountRegisterAPI);
        return this.accountService.post(JSON.stringify(newUser));
    };
    MembershipService.prototype.login = function (creds) {
        this.accountService.set(this._accountLoginAPI);
        return this.accountService.post(JSON.stringify(creds));
    };
    MembershipService.prototype.logout = function () {
        this.accountService.set(this._accountLogoutAPI);
        return this.accountService.post(null, false);
    };
    MembershipService.prototype.isUserAuthenticated = function () {
        var _user = localStorage.getItem('user');
        if (_user != null)
            return true;
        else
            return false;
    };
    MembershipService.prototype.getLoggedInUser = function () {
        var _user;
        if (this.isUserAuthenticated()) {
            var _userData = JSON.parse(localStorage.getItem('user'));
            _user = new User(_userData.Username, _userData.Password);
        }
        return _user;
    };
    return MembershipService;
}());
MembershipService = __decorate([
    Injectable(),
    __metadata("design:paramtypes", [DataService])
], MembershipService);
export { MembershipService };
//# sourceMappingURL=membership.service.js.map