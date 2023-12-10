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
  user: string = String(localStorage.getItem('user'));
  course: any = null;
  video:  string = '';
  enrolled: boolean = false;

  owner: boolean = false;
  title: string = '';
  description:  string = '';
  recourceId: string = '';


  constructor(
    private router: Router,
    private backendService: BackendService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.url.subscribe((res) => {
      this.cousreId = Number(res[1].path);
    });

    this.backendService.gatCourseById(this.cousreId).subscribe((res) => {
      this.course = res.responseData;
      this.title = this.course.name;
      this.description = this.course.description;

      if (this.course.ownerId == this.user) {
        this.owner = true;
        this.enrolled = true;
      }

      this.backendService.gatAllCourseEnrolls().subscribe((res1) => {
        res1.responseData.forEach(
          (e: { userId: string | null; courseId: Number }) => {
            if (
              e.userId == localStorage.getItem('user') &&
              e.courseId == this.cousreId
            ) {
              this.enrolled = true;
            }

          }
        );
        this.backendService.gatAllResources().subscribe((res2) =>{
          res2.responseData.forEach((m: {id:string; courseId: Number; link: string; }) => {
            if(m.courseId == this.cousreId){
              this.video = m.link;
              this.recourceId= m.id;
            }

          });
        })
      });

    });
  }

  startCourse() {
    this.backendService
      .createCourseEnroll(this.user, String(this.cousreId))
      .subscribe((res) => {
        console.log(res);
        this.enrolled = true;
      });
  }

  saveCourse(){
    this.backendService.editCourseByID(this.cousreId, this.title, this.description,this.user).subscribe(
      (res) => {
        console.log(res);
        this.backendService.editResourceByID(this.recourceId,this.title,this.video,this.cousreId).subscribe(
          (res) => {
            console.log(res);

          }
        )

      }
    )

  }
}
