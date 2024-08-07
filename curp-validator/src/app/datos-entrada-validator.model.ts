import { DatosEntrada } from "./datos-entrada.model";
import { Sexo } from "./sexo.model";

export class DatorEntradaValidator implements DatosEntrada{
    curp: string;
    nombres: string;
    apellidoPaterno: string;
    apellidoMaterno: string;
    fechaNacimiento: string;
    sexo: Sexo;
    esMexicano: boolean;
    entidadFederativa: string;

    constructor(curp: string, nombres: string, apellidoPaterno: string, apellidoMaterno: string, fechaNacimiento: string, sexo: Sexo, esMexicano: boolean, entidadFederativa: string){
        this.curp = curp;
        this.nombres = nombres;
        this.apellidoPaterno = apellidoPaterno;
        this.apellidoMaterno = apellidoMaterno;
        this.fechaNacimiento = fechaNacimiento;
        this.sexo = sexo;
        this.esMexicano = esMexicano;
        this.entidadFederativa = entidadFederativa;
    }

}