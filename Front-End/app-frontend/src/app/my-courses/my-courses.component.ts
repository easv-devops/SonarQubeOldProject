import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-courses',
  templateUrl: './my-courses.component.html',
  styleUrls: ['./my-courses.component.css']
})
export class MyCoursesComponent {

  constructor(
    private router: Router,
   //private backendService: BackendService
  ) {}

  createCourse(){
    this.router.navigate(['create-course']);

  }

  goToCourse(id:number){
    this.router.navigate(['course/' +id]);

  }
}
