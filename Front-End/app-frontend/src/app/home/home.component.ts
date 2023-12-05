import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  courses: any[] = [];
  enrolledCourses: any[] = [];


  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }

  ngOnInit(): void {
    this.backendService.gatAllCourses().subscribe(
      (res)=> {
        this.courses=res.responseData;
        console.log(this.courses);
            }
    );

    }

  selectCource(course: any){
    localStorage.setItem('selectedCourse', course.id);

    this.router.navigate(['course/' + course.id]);

  }
}
