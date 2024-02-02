import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from './backend.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {

  constructor(
    private router: Router,
   private backendService: BackendService
     ) { }

  token= localStorage.getItem("token");
  filter: string = "";

  filteredCourses: any[] = [];

  ngOnInit(): void {

      this.router.navigate(['login']);



  }
  title = 'app-frontend';

  loggedIn: boolean = true;
  page: string = 'home';


  filterData() {
    this.backendService.gatAllCourses().subscribe(

      (res) =>{
        this.filteredCourses = [];
        res.responseData.forEach((e: {id:string, name: string | string[]; }) => {
          if(e.name.includes(this.filter)){
            this.filteredCourses.push(e)
          }

        });
        console.log(this.filteredCourses);

      }
    )
      }

      selectCource(course: any){
        localStorage.setItem('selectedCourse', course.id);

        this.router.navigate(['course/' + course.id]);

      }

}
