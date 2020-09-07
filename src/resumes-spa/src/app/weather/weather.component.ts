import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']
})
export class WeatherComponent implements OnInit {
  values: any;
  
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getvalues();
  }

  getvalues() {
    this.http.get('http://localhost:5000/weatherForecast')
      .subscribe(response => {
        this.values = response;
      }, error => {
          console.log(error);
      });
  }

}
