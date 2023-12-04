import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(
    private router: Router,
   // private backendService: BackendService
  ) { }

  ngOnInit(): void {
   console.log("work")
  }

  selectCource(id:number){
    this.router.navigate(['course/' +id]);

  }
}
