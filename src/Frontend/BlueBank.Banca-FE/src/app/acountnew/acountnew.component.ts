import { Component, OnInit, Inject } from "@angular/core";
import { Acount } from "../acount";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: "app-acountnew",
  templateUrl: "./acountnew.component.html"
})
export class AcountNewComponent implements OnInit {
  public _baseUrl: string;
  public _http: HttpClient;
  // El modelo ligado al formulario, por defecto vacío
  acountModel = new Acount("", "", 0);

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
    this._http = http;
  }

  ngOnInit() {}

  formularioEnviado(){

    this._http.post<Response>(this._baseUrl + "api/Acounts/CreateAsync", this.acountModel).subscribe(result => console.log(result));
    
    console.log("El formulario fue enviado y la nueva cuenta es: ", this.acountModel);
    alert("Enviado");
  }
}

interface Response {
  data: boolean;
  isSuccess: boolean;
  messange: string;
}
