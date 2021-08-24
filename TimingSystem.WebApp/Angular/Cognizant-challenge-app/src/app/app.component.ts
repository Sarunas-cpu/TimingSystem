import { Component, OnInit } from '@angular/core';
import { HttpService } from './services/http.service';
import { Movie } from './_interfaces/movie.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  movies: Movie[] = [];
  postData = {
    clientId: "okey",
    clientSecret: "okey",
    script: "okey",
    stdin: "okey",
    language: "okey",
    versionIndex: "okey"
  };

  constructor(private httpService: HttpService){}

  ngOnInit() {
    // this.getMovies();
    this.postChallengeResponse();
    console.log();
  }

  public getMovies = () => {
    let route: string = 'http://localhost:5000/api/movies';
    this.httpService.getData(route)
    .subscribe((result) => {
      this.movies = result as Movie[];
    },
    (error) => {
      console.error(error);
    });
  }

  public postMovies = () => {
    let route: string = 'http://localhost:5000/api/movies';
    this.httpService.postData(route,this.movies)
    .subscribe((result) => {
      this.movies = result as Movie[];
    },
    (error) => {
      console.error(error);
    });
  }



  
  public postChallengeResponse = () => {
    let route: string = 'https://api.jdoodle.com/v1/execute';
    debugger;



    var kazkas = this.httpService.postData(route, this.postData).toPromise().then(data => console.log(data));
  }
 }