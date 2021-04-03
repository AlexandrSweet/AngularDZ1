import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { User } from './User';

@Component({
  selector: 'app-privat-data',
  templateUrl: './privat-data.component.html',
  styleUrls: ['./privat-data.component.css']
})
export class PrivatDataComponent implements OnInit {
  public privateDataset: Array<User>;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get <Array<User>>(baseUrl + 'privatdata/get-private-users').subscribe(
      result => { this.privateDataset = result; },
      error => { console.log("privatedate says: " + error); });
  }
  ngOnInit() {
  }

}
