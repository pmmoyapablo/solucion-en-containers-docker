import { Component, OnInit, Inject } from "@angular/core";
import { Acount } from "../acount";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "app-acountmove",
  templateUrl: "./acountmove.component.html"
})
export class AcountMoveComponent implements OnInit {
  public _baseUrl: string;
  public _http: HttpClient;
  // El modelo ligado al formulario, por defecto vacío
  acountModel = new Acount("", "", 0);

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this._http = http;
  }

  ngOnInit() { }

  formularioEnviado() {

    this._http.put<Response>(this._baseUrl + "api/Acounts/MoveAsync", this.acountModel).subscribe(result => console.log(result));

    console.log("El formulario fue enviado y la transacion cuenta es: ", this.acountModel)
    alert("Enviado");
  }
}

interface Response {
  data: boolean;
  isSuccess: boolean;
  messange: string;
}
