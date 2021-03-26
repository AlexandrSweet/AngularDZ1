import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { User } from '../privat-data/User';

@Component({
  selector: 'app-public-data',
  templateUrl: './public-data.component.html',
  styleUrls: ['./public-data.component.css']
})
export class PublicDataComponent implements OnInit {
  public publicDataset: Array<User>;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Array<User>>(baseUrl + 'publicdata/get-publicUsers').subscribe(
      result => { this.publicDataset = result; },
      error => { console.log("privatedate says: " + error); });
  }
  ngOnInit() {
  }

}
