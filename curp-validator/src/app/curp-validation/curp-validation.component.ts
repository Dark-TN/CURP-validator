import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Sexo } from '../sexo.model';
import { CurpValidatorService } from '../curp-validator.service';
import { DatorEntradaValidator } from '../datos-entrada-validator.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-curp-validation',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './curp-validation.component.html',
  styleUrl: './curp-validation.component.css'
})
export class CurpValidationComponent {
  title: string = 'Validacion de CURP';
  curp: string = '';
  nombres: string = '';
  apellidoPaterno: string = '';
  apellidoMaterno: string = '';
  fechaNacimiento: string = '';
  sexo: Sexo = Sexo.Masculino;
  esMexicano: boolean = true;
  entidadFederativa: string = '';
  errores: string[] = [];

  constructor(private curpValidatorService: CurpValidatorService){

  }

  setMasculino():void{
    this.sexo = Sexo.Masculino;
  }

  setFemenino():void{
    this.sexo = Sexo.Femenino;
  }

  setEsMexicano(): void{
    this.esMexicano = !this.esMexicano;
  }

  validate(){
    let datosEntrada: DatorEntradaValidator = new DatorEntradaValidator(this.curp, this.nombres, this.apellidoPaterno, this.apellidoMaterno, this.fechaNacimiento + 'T00:00:00.000Z', this.sexo, this.esMexicano, this.entidadFederativa);

    this.curpValidatorService.postValidateCurp(datosEntrada).subscribe(result => this.errores = result);
  }

}
