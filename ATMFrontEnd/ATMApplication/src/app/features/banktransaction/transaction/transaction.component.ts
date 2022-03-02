import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BankAccount, Transaction } from 'src/app/core/model';
import { LoginService } from 'src/app/core/services/login.service';
import { BankTransactionService } from 'src/app/core/services/transaction-service/bank-transaction.service';

@Component({
  selector: 'app-transaction',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class TransactionComponent implements OnInit {
  bankAccount: BankAccount = new BankAccount(0, '', 0, 0, 0);
  amount: number = 0;
  transactionHistory: Transaction[] = [];
  cols: any[] = [];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private bankTransactionService: BankTransactionService,
    private loginService: LoginService,
    ) { }

  ngOnInit(): void {
    this.getBankTransactionDetails();
    this.getTransactionHistory()

    //
    this.cols = [
      { field: 'transactionDate', header: 'transactionDate' },
      { field: 'bankAccountNoFrom', header: 'bankAccountNoFrom' },
      { field: 'bankAccountNoTo', header: 'bankAccountNoTo' },
      { field: 'transactionTypes', header: 'transactionTypes' },
      { field: 'transactionAmount', header: 'transactionAmount' },
      
    ];

  }
  getBankTransactionDetails(): void {

    this.bankTransactionService.getBankDetails().subscribe({
      next: (bankDetails) => {
        if (bankDetails) {
          this.bankAccount = bankDetails;
        }

      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    });

  }

  deposit() {
    // allow only multiple hundred
    if (this.amount % 100 === 0) {
      this.bankAccount.balance += this.amount;
      this.bankTransactionService.updateBankAccountBalance(
        this.bankAccount.id, this.bankAccount).subscribe({
          next: () => {
            this.getBankTransactionDetails();
            const transaction = new Transaction(
              0,
              this.bankAccount.accountNumber,
              this.bankAccount.accountNumber,
              0,
              this.bankAccount.balance,
              new Date()
            );

            this.insertTransactionHistory(transaction);
          },
          error: (e) => console.error(e),
          complete: () => console.info('complete')

        });
    }
  }

  withdrawal() {
    if (this.amount % 100 === 0) {
      this.bankAccount.balance -= this.amount;
      this.bankTransactionService.updateBankAccountBalance(
        this.bankAccount.id, this.bankAccount).subscribe({
          next: () => {
            this.getBankTransactionDetails();
            this.getBankTransactionDetails();
            const transaction = new Transaction(
              0,
              this.bankAccount.accountNumber,
              this.bankAccount.accountNumber,
              1,
              this.bankAccount.balance,
              new Date()
            );

            this.insertTransactionHistory(transaction);
          }
        });

    }
  }

  insertTransactionHistory(transaction: Transaction) {
    this.bankTransactionService.insertTransactionHistory(transaction).subscribe({
      next: () => {
        this.getTransactionHistory();
      }
      // update grid
    });
  }
  getTransactionHistory() {
    this.bankTransactionService.getTransaction().subscribe({
      next: (response) => {
        this.transactionHistory = response;
        console.log(this.transactionHistory)
      }
    });
  }

  logout(){
   this.loginService.logout();
   this.router.navigate(['/login']);
  }



}
