export class BankAccount {
    id: number;
    fullName: string;
    accountNumber: number;
    cardNumber: number;
    balance:number
    constructor( id: number,
        fullName: string,
        accountNumber: number,
        cardNumber: number,
        balance:number) {
         this.id = id;
         this.fullName = fullName;
         this.accountNumber = accountNumber;
         this.cardNumber =  cardNumber;
         this.balance = balance;
    }
}