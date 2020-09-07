import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators'
import { Profile } from '../_models/profile';
import { PaginatedResult } from '../_models/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  getProfiles(page?, itemsPerPage?): Observable<PaginatedResult<Profile[]>> {
    const paginatedResult: PaginatedResult<Profile[]> = new PaginatedResult<Profile[]>();
    let params = new  HttpParams();
    if(page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    return this.http.get<Profile[]>('http://localhost:5000/api/profiles',
      {observe: 'response', params})
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if(response.headers.get('Pagination') != null){
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
          }
          console.log(paginatedResult);
          return paginatedResult;
        })
      );
  }
}
