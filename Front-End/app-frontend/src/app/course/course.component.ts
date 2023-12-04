import { Component } from '@angular/core';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css'],
})
export class CourseComponent {
  enrolled: boolean = false;

  owner: boolean = false;

  startCourse() {
    this.enrolled = true;
  }
}
