import { Component, OnInit, Inject } from "@angular/core";
import { Acount } from "../acount";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "app-acountget",
  templateUrl: "./acountget.component.html"
})
export class AcountGetComponent implements OnInit {
  public _baseUrl: string;
  public _http: HttpClient;
  public _result: Response;
  // El modelo ligado al formulario, por defecto vacío
  acountModel = new Acount("", "", 0);

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this._http = http;
  }

  ngOnInit() { }

  formularioEnviado() {

    this._http.get<Response>(this._baseUrl + 'api/Acounts/GetAsync/' + this.acountModel.code).subscribe(result => {
      this._result = result;
    }, error => console.error(error));

    console.log("El formulario fue enviado y la consulta de la cuenta es: ", this._result.data);
    alert("Procesado");
  }
}


interface Response {
  data: AcountI;
  isSuccess: boolean;
  messange: string;
}

interface AcountI {
  code: string;
  customerID: string;
  amount: number
}
