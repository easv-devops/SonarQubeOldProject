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
  video: string = '';
  enrolled: boolean = false;

  owner: boolean = false;
  title: string = '';
  description: string = '';
  recourceId: string = '';
  selected: string = '';
  levelOfEducation: string = '';

  titleReg : RegExp = /^[a-zA-Z ]{6,30}$/;
  descriptionReg : RegExp =/^[a-zA-Z ]{10,30}$/;

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

      switch (this.course.experienceLevel) {
        case 1:
          this.levelOfEducation = 'Beginner';
          break;
        case 2:
          this.levelOfEducation = 'Intermediate';
          break;
        case 3:
          this.levelOfEducation = 'Advanced';
          break;
      }

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
        this.backendService.gatAllResources().subscribe((res2) => {
          res2.responseData.forEach(
            (m: { id: string; courseId: Number; link: string }) => {
              if (m.courseId == this.cousreId) {
                this.video = m.link;
                this.recourceId = m.id;
              }
            }
          );
        });
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

  saveCourse() {
    if(this.titleReg.test(this.title) && this.title!='Incorrect course info ' && this.descriptionReg.test(this.description) && this.video.length>10){

    this.backendService
      .editCourseByID(
        this.cousreId,
        this.title,
        this.description,
        this.user,
        this.selected
      )
      .subscribe((res) => {
        console.log(res);
        this.backendService
          .editResourceByID(
            this.recourceId,
            this.title,
            this.video,
            this.cousreId
          )
          .subscribe((res) => {
            console.log(res);
          });
      });
    }else{
      this.title = "Incorrect course info "
    }
  }
}
