import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html'
})
export class CustomerComponent {
  public forecasts: ResponseForecast;
  //api/SampleData/BookForecasts
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ResponseForecast>(baseUrl + 'api/Customers/GetAllAsync').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface ResponseForecast {
  data: CustomerForecast[];
  isSuccess: boolean;
  messange: string;
}

interface CustomerForecast {
  customerId: string;
  contactName: string;
  city: string;
  phone: string;
}
