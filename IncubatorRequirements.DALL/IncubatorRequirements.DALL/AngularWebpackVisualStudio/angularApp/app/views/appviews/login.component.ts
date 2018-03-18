import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../account/user';
import { OperationResult } from '../../utilities/operationResult';
import { MembershipService } from '../../services/membership.service';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'login',
  templateUrl: 'login.template.html'
})
export class LoginComponent implements OnInit { 
      private _user: User;

    constructor(public membershipService: MembershipService,
                public notificationService: NotificationService,
                public router: Router) { }

    ngOnInit() {
        this._user = new User('', '');
    }

    login(): void {
        var _authenticationResult: OperationResult = new OperationResult(false, '');

        this.membershipService.login(this._user)
            .subscribe((res:any) => {
                _authenticationResult.Succeeded = res.Succeeded;
                _authenticationResult.Message = res.Message;
            },
            error => console.error('Error: ' + error),
            () => {
                if (_authenticationResult.Succeeded) {
                    this.notificationService.printSuccessMessage('Welcome back ' + this._user.Username + '!');
                    localStorage.setItem('user', JSON.stringify(this._user));
                    this.router.navigate(['home']);
                }
                else {
                    this.notificationService.printErrorMessage(_authenticationResult.Message);
                }
            });
    };
}
