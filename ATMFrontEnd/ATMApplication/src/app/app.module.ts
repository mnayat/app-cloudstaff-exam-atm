import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
//primeng

import { InputTextModule } from 'primeng/inputtext';
import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';
import { InputNumberModule } from 'primeng/inputnumber';
import {TableModule} from 'primeng/table';

// Components
import { AppComponent } from './app.component';
import { LoginComponent } from './features/login/login.component';
import { TransactionComponent } from './features/banktransaction/transaction/transaction.component';
//Service
import { LoginService } from './core/services/login.service';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TransactionComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    InputTextModule,
    InputNumberModule,
    PanelModule,
    ButtonModule,
    HttpClientModule,
    FormsModule,
    TableModule,
    RouterModule.forRoot([
      { 
        path: 'login', 
        component: LoginComponent 
      },
      { 
        path: '', 
        component: TransactionComponent 
      },
      { 
        path: '', 
        redirectTo: 'login',
        pathMatch: 'full' }
    ])


  ],
  providers: [
    LoginService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
