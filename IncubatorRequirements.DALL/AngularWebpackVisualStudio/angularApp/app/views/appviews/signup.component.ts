import { Component,OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Registration } from '../account/registration';
import { OperationResult } from '../../utilities/operationResult';
import { MembershipService } from '../../services/membership.service';
import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'signup',
  templateUrl: 'signup.component.html'
})
export class SignUpComponent implements OnInit  { 

    private _newUser: Registration;
    constructor(public membershipService: MembershipService,
                public notificationService: NotificationService,
                public router: Router) { }

    ngOnInit() {
        this._newUser = new Registration('', '', '','');
    }

        register(): void {
        var _registrationResult: OperationResult = new OperationResult(false, '');
        this.membershipService.register(this._newUser)
            .subscribe((res:any) => {
                _registrationResult.Succeeded = res.Succeeded;
                _registrationResult.Message = res.Message;

            },
            error => console.error('Error: ' + error),
            () => {
                if (_registrationResult.Succeeded) {
                    this.notificationService.printSuccessMessage('Dear ' + this._newUser.Username + ', please login with your credentials');
                    this.router.navigate(['/login']);
                }
                else {
                    this.notificationService.printErrorMessage(_registrationResult.Message);
                }
            });
    };

}