export class User {
    id: number;
    username: string;
    password: string;
    accountNumber:number;

    constructor(id: number, username: string, password: string, accountNumber:number) {
        this.id = id;
        this.username = username;
        this.password = password;
        this.accountNumber = accountNumber;
    }
}