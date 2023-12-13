import { Injectable } from '@angular/core';
import { environment } from './enviroments';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
      boxID: id,
      BoxName: name,
    });
  }

  createUser(
    name: string,
    username: string,
    email: string,
    password: string
  ): Observable<any> {
    const url = environment.backendapi + '/api/Users';
    return this.http.post<any>(url, {
      id: 0,
      username: username,
      email: email,
      password: password,
      shortDescription: name,
    });
  }

  //Course
  gatAllCourses(): Observable<any> {
    const url = environment.backendapi + '/api/Course';
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });
    return this.http.get<any[]>(url, { headers });
  }

  gatCourseById(id: Number): Observable<any> {
    const url = environment.backendapi + '/api/Course/' + id;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });
    return this.http.get<any>(url, { headers });
  }

  removeCourseByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/Course/' + id;
    return this.http.delete<any>(url);
  }

  editCourseByID(id: Number, name: string, description: string, ownerId: string, level: string ): Observable<any> {
    const url = environment.backendapi + '/api/Course/' + id;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    const courseData = {
      name: name,
      experienceLevel: level,
      description: description,
      ownerId: ownerId,
      price: 0,
    };
    return this.http.put<any>(url,courseData,{headers});
  }

  createCourse(name: string, description: string, id: string, level: string): Observable<any> {
    const url = environment.backendapi + '/api/Course';
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    const courseData = {
      name: name,
      experienceLevel: level,
      description: description,
      ownerId: id,
      price: 0,
    };
    return this.http.post<any>(url, courseData, { headers });
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
      boxID: id,
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
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    return this.http.get<any[]>(url, { headers });
  }

  gatCourseEnrollById(id: string): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll/' + id;
    return this.http.get<any>(url);
  }

  removeCourseEnrollByID(id: any): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll/' + id;
    return this.http.delete<any>(url);
  }

  editCourseEnrollByID(id: number, name: string): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll/' + id;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    const data = {
      id: id,
    };
    return this.http.put<any>(url, data, { headers });
  }

  createCourseEnroll(userId: string, courseId: string  ): Observable<any> {
    const url = environment.backendapi + '/api/CourseEnroll';
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    const data = {
      userId: userId,
      courseId: courseId,
    };
    return this.http.post<any>(url,data , {
      headers
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

  editResourceByID(id: string, name: string, video: string, courseId: Number): Observable<any> {
    const url = environment.backendapi + '/api/Resource/' + id;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    const videoData = {
      name: name,
      type: "video",
      link: video,
      courseId: courseId,
    };

    return this.http.put<any>(url,videoData, {
      headers
    });
  }

  createResource(name: string, video: string, id: string): Observable<any> {
    const url = environment.backendapi + '/api/Resource';
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ${localStorage.getItem('token')}`,
    });

    const videoData = {
      name: name,
      type: video,
      link: video,
      courseId: id,
    };

    return this.http.post<any>(url, videoData, { headers });
  }

  //Auth
  logIn(name: string, password: string): Observable<any> {
    const url = environment.backendapi + '/api/Auth/login';
    return this.http.post<any>(url, {
      username: name,
      password: password,
    });
  }
}
