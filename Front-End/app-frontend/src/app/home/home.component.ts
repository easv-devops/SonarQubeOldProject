import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  courses: any[] = [];
  myCourses: any[] = [];
  enrolledCourses: any[] = [];
  allCourses: any[] = [];
  level: string = "";

  constructor(private router: Router, private backendService: BackendService) {}

  ngOnInit(): void {
    this.backendService.gatAllCourses().subscribe((res) => {
      this.courses = res.responseData;
      this.allCourses = this.courses;
      console.log(this.courses);
      this.backendService.gatAllCourseEnrolls().subscribe((res1) => {
        res1.responseData.forEach(
          (e: { userId: string | null; courseId: Number }) => {
            if (e.userId == localStorage.getItem('user')) {
              this.courses.forEach((c) => {
                if (c.id == e.courseId) {
                  this.myCourses.push(c);
                }
              });
            }
          }
        );
      });
    });
  }

  selectCource(course: any) {
    localStorage.setItem('selectedCourse', course.id);

    this.router.navigate(['course/' + course.id]);
  }

  selectCategory(type: number) {

    switch (type) {
      case 1:
        this.courses = this.allCourses;
        this.courses = this.courses.filter((e) => e.courseLevel.level === 'Beginner');
       this.level = 'Beginner'
        break;
      case 2:
        this.courses = this.allCourses;
        this.courses = this.courses.filter((e) => e.courseLevel.level === 'Intermediate');
        this.level = 'Intermediate'

             break;
      case 3:
        this.courses = this.allCourses;
        this.courses =  this.courses.filter((e) => e.courseLevel.level === 'Advanced');
        this.level = 'Advanced'

        break;
      case 4:
        this.courses = this.allCourses;
        this.courses =  this.courses.filter((e) => e.courseLevel.level === 'Professional');
        this.level = 'Professional'

        break;
    }
  }

  myCoursesButton(){
    this.router.navigate(['my-courses']);

  }
}
