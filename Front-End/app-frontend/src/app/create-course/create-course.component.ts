import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from '../backend.service';

@Component({
  selector: 'app-create-course',
  templateUrl: './create-course.component.html',
  styleUrls: ['./create-course.component.css'],
})
export class CreateCourseComponent {
  title: string = '';
  description:  string = '';
  video:  string = '';
  user : string = String(localStorage.getItem('user'));
  selected: string = "";
  titleReg : RegExp = /^[a-zA-Z ]{6,30}$/;
  descriptionReg : RegExp =/^[a-zA-Z ]{10,30}$/;


  constructor(
    private router: Router,
   private backendService: BackendService
  ) { }



  createCourse(){
    if(this.titleReg.test(this.title) && this.title!='Incorrect course info '
    && this.descriptionReg.test(this.description) && this.video.length>10){

    this.backendService.createCourse(this.title,this.description, this.user, this.selected).subscribe(
      (res) => {
        if(res.messageToClient=="Here is the created course api.TransferModels.CourseDto.CreateCourseDto"){
          this.backendService.createResource(this.title,this.video, res.responseData.id).subscribe((res1)=>{
            if(res1.messageToClient){
              console.log(res1.responseData.courseId);
              this.router.navigate(['course/'+res1.responseData.courseId]);
            }
          })
        }
      }
    )
    }else{
      this.title = "Incorrect course info "
    }

  }
}
