import { Component, OnInit } from '@angular/core';

import { ProfileService } from '../_services/profile.service';
import { Profile } from '../_models/profile';
import { Pagination } from '../_models/pagination';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  pageNumber = 1;
  pageSize = 1;
  profiles: Profile[];
  pagination: Pagination;
  constructor(private profileService: ProfileService) { }

  

  ngOnInit() {
    this.loadProfiles(this.pageNumber, this.pageSize);
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadProfiles(this.pagination.currentPage, this.pagination.itemsPerPage);
  }

  loadProfiles(pageNumber, pageSize) {
    this.profileService.getProfiles(pageNumber, pageSize)
      .subscribe(data => {
        this.profiles = data.result;
        this.pagination = data.pagination;
        console.log(this.profiles);
      })
  }

}
