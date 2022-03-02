import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/core/services/login.service';
import { AuthenticationModel, User } from 'src/app/core/model/index';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userName: string = '';
  password: string = '';

  returnUrl: string='';
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private loginService: LoginService) { }

  ngOnInit(): void {
    this.loginService.logout();
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  login(): void {
    const authenticate = new AuthenticationModel(this.userName, this.password);
    this.loginService.getUserDetails(authenticate).subscribe({
      next: (user) => {
        
         localStorage.setItem('accountnumber', user.accountNumber.toString() );
         this.router.navigate([this.returnUrl]);
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete') 
  });
  }

}
