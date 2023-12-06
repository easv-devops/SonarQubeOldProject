import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.css'],
})
export class CreateCourseComponent {
  title: any;
  description: any;
  video: any;

  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }



  createCourse(){

    this.backendService.createCourse(this.title,this.description, this.video).subscribe(
      (res) => {
        console.log(res);
      }
    )

  }
}
