import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-privat-data',
  templateUrl: './privat-data.component.html',
  styleUrls: ['./privat-data.component.css']
})
export class PrivatDataComponent implements OnInit {
  public privateDataset: Array<string>;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get <Array<string>>(baseUrl + 'privatdata').subscribe(
      result => { this.privateDataset = result; },
      error => { console.log("privatedate says: " + error); });
  }
  ngOnInit() {
  }

}
