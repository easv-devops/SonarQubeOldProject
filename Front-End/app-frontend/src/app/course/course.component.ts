import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.css'],
})
export class CourseComponent implements OnInit {

  cousreId: Number = Number(localStorage.getItem('selectedCourse'));
  course: any = null;

  constructor(
    private router: Router,
   private backendService: BackendService,
   private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.url.subscribe((res)=>{
      this.cousreId = Number(res[1].path);
    });

    this.backendService.gatCourseById(this.cousreId).subscribe(
      (res) => {
        this.course = res.responseData;
        console.log(this.course)
      }
    )

  }
  enrolled: boolean = false;

  owner: boolean = false;

  startCourse() {
    this.enrolled = true;
  }
}
