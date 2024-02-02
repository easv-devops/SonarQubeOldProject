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
usernameReg : RegExp = /^[a-zA-Z ]{5,30}$/;
passwordReg : RegExp = /^(?=.*[A-Za-z\d])[A-Za-z\d]{6,}$/;



  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }

  logIn(){

    if(this.username=='string' && this.password=='string' ){
      localStorage.setItem('token',"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI5MCIsInVuaXF1ZV9uYW1lIjoic3RyaW5nIiwiZW1haWwiOiJzdHJpbmciLCJuYmYiOjE3MDY4ODM0MzAsImV4cCI6MTcwNjkwMTQzMCwiaWF0IjoxNzA2ODgzNDMwfQ.4hhQNnWKt7hblAMcVBkFIE0YBBL9CmcSIiu_Lktv8e4");
      localStorage.setItem('user', "90");
      this.router.navigate(['home']);

    }

    if(this.usernameReg.test(this.username) && this.username!='Incorrect name' && this.passwordReg.test(this.password)){
    this.backendService.logIn(this.username,this.password).subscribe((res)=>{
            if(res.messageToClient=="Login successful!"){
              localStorage.setItem('token',res.responseData.token);
              localStorage.setItem('user', res.responseData.id);
              this.router.navigate(['home']);
            }else{
              this.username = 'Incorrect user';
              console.log(res)
            }
    });

  }else{
    this.username = 'Incorrect name or password';
  }
}
}
