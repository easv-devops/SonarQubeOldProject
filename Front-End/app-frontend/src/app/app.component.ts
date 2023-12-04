import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
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
