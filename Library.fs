namespace sharptest
open System.Collections.Generic
    module Resta =
        let fres (x:float, y:float) :double=
            x - y 
    module Suma =
        let fsum (x:float, y:float) =
            x + y 
    module Multiplicacion =
        let fmul (x:float, y:float) =
            x * y 
    module Division =
        let fdiv (x:float, y:float) =
            x / y 
    module ListaEquipamiento =
        let booksList = new List<string>()
        let agregar (nombre:string)=
            booksList.Add(nombre)
        let limpiar ()=
            booksList.Clear()
    module MovimientoZ = 
        let rotando (direccionZ:float, tiempo:float, velocidad:float) =
            direccionZ * tiempo * velocidad
    module Gravedad =
        let calculandoGravedad (direccionY:float, gravedad:float, tiempo:float) =
            direccionY - (gravedad * tiempo)
    module GolpeMiedo =
        let calculandoDanio (miedo:float, danio:float) =
            danio - ((danio*0.7) * (miedo/100.0))
    module VulnerabilidadMiedo =
        let bajandoVidaMiedo (miedo:float, danio:float) =
            danio + ((danio*0.7) * (miedo/100.0))   
    module BajandoMiedo = 
        let bajandoMiedo (enemigos:float) =
            (enemigos / 10.0) + 0.1