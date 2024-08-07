import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DatosEntrada } from './datos-entrada.model';

@Injectable({
  providedIn: 'root'
})
export class CurpValidatorService {

  constructor(private http: HttpClient) { }

  postValidateCurp(datosEntrada: DatosEntrada){
    return this.http.post<string[]>("https://localhost:7016/api/DatosPersonales", datosEntrada);
  }
}
