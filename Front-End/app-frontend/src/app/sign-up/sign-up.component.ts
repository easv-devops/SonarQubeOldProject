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


  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }

  createUser(){
    this.backendService.createUser(this.name,this.username,this.email,this.password).subscribe((res)=>{
     if(res.messageToClient=="Here is the created user: api.TransferModels.UserDto.CreateUserDto"){
      localStorage.setItem('token',res.responseData.token);
      localStorage.setItem('user', res.responseData.id);
      this.router.navigate(['home']);
     }



      console.log(this.name)
    })

  }
}
