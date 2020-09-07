import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { WeatherComponent } from './weather/weather.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [		
    AppComponent,
      WeatherComponent,
      ProfileComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    PaginationModule.forRoot(),
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
