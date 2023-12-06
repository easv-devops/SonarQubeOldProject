import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LogInComponent } from './log-in/log-in.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { CourseComponent } from './course/course.component';
import { CreateCourseComponent } from './create-course/create-course.component';
import { MyCoursesComponent } from './my-courses/my-courses.component';

const routes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'login',
    component: LogInComponent,
  },
  {
    path: 'signup',
    component: SignUpComponent,
  },
  {
    path: 'course/:id',
    component: CourseComponent,
  },
  {
    path: 'create-course',
    component: CreateCourseComponent,
  },
  {
    path: 'my-courses',
    component: MyCoursesComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

}
