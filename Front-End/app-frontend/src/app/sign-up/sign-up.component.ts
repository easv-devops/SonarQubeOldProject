import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
name: string = "";
username: string = "";
email: string = "";
password: string = "";
usernameReg : RegExp = /^[a-zA-Z ]{5,30}$/;
passwordReg : RegExp = /^(?=.*[A-Za-z\d])[A-Za-z\d]{6,}$/;
nameReg : RegExp = /^[a-zA-Z ]{10,30}$/;
emailReg : RegExp = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;





  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }

  createUser(){
    if(this.usernameReg.test(this.username)
    && this.username!='Incorrect name, email, username or password'
    && this.passwordReg.test(this.password)
    && this.nameReg.test(this.name)
    && this.emailReg.test(this.email)){

    this.backendService.createUser(this.name,this.username,this.email,this.password).subscribe((res)=>{
     if(res.messageToClient=="Here is the created user: api.TransferModels.UserDto.CreateUserDto"){
      localStorage.setItem('token',res.responseData.token);
      localStorage.setItem('user', res.responseData.id);
      this.router.navigate(['home']);
     }
      console.log(this.name)
    })
  }else{
    this.username = 'Incorrect name, email, username or password';
    this.name = 'Incorrect name, email, username or password';
    this.email = 'Incorrect name, email, username or password';

  }

  }
}
