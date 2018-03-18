export class Registration {
    Username: string;
    Password: string;
    Email: string;
    FullName:string

    constructor(username: string,
        password: string,
        email: string,fullname:string) {
        this.Username = username;
        this.Password = password;
        this.Email = email;
        this.FullName =fullname;
    }
}