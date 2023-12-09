import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent {
username: string = '';
password: string = '';

  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }

  logIn(){
    this.backendService.logIn(this.username,this.password).subscribe((res)=>{
            if(res.messageToClient=="Login successful!"){
              localStorage.setItem('token',res.responseData.token);
              localStorage.setItem('user', res.responseData.id);
              this.router.navigate(['home']);
            }
    });

  }
}
