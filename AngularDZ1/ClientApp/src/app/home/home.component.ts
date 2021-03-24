import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public setting: Settings
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Settings>(baseUrl + 'weatherforecast/get-settings').subscribe(result => {
      this.setting = result;
    }, error => console.error(error));
  }
}
export class Settings {
  environmentSettings: EnvironmentSettings;
}
export class EnvironmentSettings {
  name: string;
}
