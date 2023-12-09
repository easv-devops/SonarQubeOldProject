import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from './backend.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {

  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }

  token= localStorage.getItem("token");

  ngOnInit(): void {
    if(this.token==null){
      this.router.navigate(['login']);

    }

  }
  title = 'app-frontend';

  loggedIn: boolean = true;
  page: string = 'home';


  switchScreen(type: string) {
    switch (type) {
      case 'course':
        this.page = type;
        break;

      case 'create-course':
        this.page = type;
        break;

      case 'my-courses':
        this.page = type;
        console.log('work')
        break;

      case 'create-course':
        this.page = type;
        break;
    }
  }
}
