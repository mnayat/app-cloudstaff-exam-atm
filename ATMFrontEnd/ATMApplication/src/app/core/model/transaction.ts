export class Transaction {
    id: number;
    bankAccountNoFrom: number;
    bankAccountNoTo: number;
    transactionTypes: number;
    transactionAmount:number;
    transactionDate: Date = new Date();
    constructor(
     id: number,
    bankAccountNoFrom: number,
    bankAccountNoTo: number,
    transactionType: number,
    transactionAmount:number,
    transactionDate:Date) {
         this.id = id;
         this.bankAccountNoFrom = bankAccountNoFrom;
         this.bankAccountNoTo = bankAccountNoTo;
         this.transactionTypes =  transactionType;
         this.transactionAmount = transactionAmount;
         this.transactionDate = transactionDate;
    }
}