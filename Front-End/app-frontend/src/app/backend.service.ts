import { Injectable } from '@angular/core';
import { environment } from './enviroments';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root',
})
export class BackendService {
  constructor(private http: HttpClient) {}

  //Users
  gatAllUsers(): Observable<any> {
    const url = environment.backendapi + '/api/Users';
    return this.http.get<any[]>(url);
  }

  gatUserById(id: number): Observable<any> {
    const url = environment.backendapi + '/api/Users/' + id;
    return this.http.get<any>(url);
  }

  removeUserByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/Users/' + id;
    return this.http.delete<any>(url);
  }

  editUserByID(id: number, name: string): Observable<any> {
    const url = environment.backendapi + '/api/Users/' + id;
    return this.http.put<any>(url, {
      boxID:id,
      BoxName: name,
    });
  }

  createUser(name: string): Observable<any> {
    const url = environment.backendapi + '/api/User';
    return this.http.post<any>(url, {
      BoxName: name,
    });
  }





  //Course
  gatAllCourses(): Observable<any> {
    const url = environment.backendapi + '/api/Course';
    return this.http.get<any[]>(url);
  }

  gatCourseById(id: number): Observable<any> {
    const url = environment.backendapi + '/api/Course/' + id;
    return this.http.get<any>(url);
  }

  removeCourseByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/Course/' + id;
    return this.http.delete<any>(url);
  }

  editCourseByID(id: number, name: string): Observable<any> {
    const url = environment.backendapi + '/api/Course/' + id;
    return this.http.put<any>(url, {
      boxID:id,
      BoxName: name,
    });
  }

  createCourse(name: string): Observable<any> {
    const url = environment.backendapi + '/api/Course';
    return this.http.post<any>(url, {
      BoxName: name,
    });
  }




  //CourseLevel
  gatAllCourseLevels(): Observable<any> {
    const url = environment.backendapi + '/api/CourseLevel';
    return this.http.get<any[]>(url);
  }

  gatCourseLevelById(id: number): Observable<any> {
    const url = environment.backendapi + '/api/CourseLevel/' + id;
    return this.http.get<any>(url);
  }

  removeCourseLevelByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/CourseLevel/' + id;
    return this.http.delete<any>(url);
  }

  editCourseLevelByID(id: number, name: string): Observable<any> {
    const url = environment.backendapi + '/api/CourseLevel/' + id;
    return this.http.put<any>(url, {
      boxID:id,
      BoxName: name,
    });
  }

  createCourseLevel(name: string): Observable<any> {
    const url = environment.backendapi + '/api/CourseLevel';
    return this.http.post<any>(url, {
      BoxName: name,
    });
  }





  //CourseEnroll
  gatAllCourseEnrolls(): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll';
    return this.http.get<any[]>(url);
  }

  gatCourseEnrollById(id: number): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll/' + id;
    return this.http.get<any>(url);
  }

  removeCourseEnrollByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll/' + id;
    return this.http.delete<any>(url);
  }

  editCourseEnrollByID(id: number, name: string): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll/' + id;
    return this.http.put<any>(url, {
      boxID:id,
      BoxName: name,
    });
  }

  createCourseEnroll(name: string): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll';
    return this.http.post<any>(url, {
      BoxName: name,
    });
  }





   //Resources
   gatAllResources(): Observable<any> {
    const url = environment.backendapi + '/api/Resource';
    return this.http.get<any[]>(url);
  }

  gatResourceById(id: number): Observable<any> {
    const url = environment.backendapi + '/api/Resource/' + id;
    return this.http.get<any>(url);
  }

  removeResourceByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/Resource/' + id;
    return this.http.delete<any>(url);
  }

  editResourceByID(id: number, name: string): Observable<any> {
    const url = environment.backendapi + '/api/Resource/' + id;
    return this.http.put<any>(url, {
      boxID:id,
      BoxName: name,
    });
  }

  createResourceEnroll(name: string): Observable<any> {
    const url = environment.backendapi + '/api/Resource';
    return this.http.post<any>(url, {
      BoxName: name,
    });
  }


  }

