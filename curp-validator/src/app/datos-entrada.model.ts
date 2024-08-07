import { Sexo } from "./sexo.model"

export interface DatosEntrada{
    curp: string;
    nombres: string;
    apellidoPaterno: string;
    apellidoMaterno: string;
    fechaNacimiento: string;
    sexo: Sexo;
    esMexicano: boolean;
    entidadFederativa: string;
}