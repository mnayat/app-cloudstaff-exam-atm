import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BankAccount, Transaction } from '../../model/index';

@Injectable({
  providedIn: 'root'
})
export class BankTransactionService {
  baseUrl: string = 'https://localhost:44371/api/';
  headers: any = { 'Content-Type': 'application/json' }

  constructor(private http: HttpClient) {

  }

  getBankDetails(): Observable<BankAccount> {
    let accountNumber = localStorage.getItem("accountnumber");
    return this.http.get<BankAccount>(`${this.baseUrl}bankaccount/${accountNumber}`);
  }


  updateBankAccountBalance(bankAccountId: number, bankDetails: BankAccount): Observable<any> {

    const body = JSON.stringify(bankDetails);
    return this.http.patch(`${this.baseUrl}bankaccount/${bankAccountId}`, body, { 'headers': this.headers });
  }

  insertTransactionHistory(bankTransactionHistory: Transaction): Observable<any> {
    const body = JSON.stringify(bankTransactionHistory);
    return this.http.post(`${this.baseUrl}transaction`, body, { 'headers': this.headers });
  }

  getTransaction(): Observable<Transaction[]> {
    return this.http.get<Transaction[]>(`${this.baseUrl}transaction`);
  }
}
