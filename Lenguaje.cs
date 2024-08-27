using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

/*
    1.Colocar el numero de linea en errores lexicos y sintacticos
    2.Cambiar la clase token por atributos publicos (get y set)
    2.Cambiar los constructores de la clase lexico usando parametros por default 
*/

namespace Semantica
{

    public class Lenguaje : Sintaxis
    {
        public Lenguaje()
        {

        }
        public Lenguaje(string nombre) : base(nombre)
        {

        }

        //Programa -> Libreria? Variable? main

        public void Programa()
        {
            //Libreria? Variable? main
            Librerias();
            Variables();
            Main();
        }

        private void Librerias()
        {
            match("Using");
            listalibrerias();
            match(":");
            if(getContenido() == "using"){
                Librerias();
            }
        }

        private void listalibrerias()
        {
            match(Tipos.Identificador);
            if(getContenido() == ".")
            {
                match(".");
                listalibrerias();
            }
        }
/*Programa  -> Librerias? Variables? Main
Librerias -> using ListaLibrerias; Librerias?
Variables -> tipo_dato Lista_identificadores; Variables?
ListaLibrerias -> identificador (.ListaLibrerias)?
ListaIdentificadores -> identificador (,ListaIdentificadores)?
BloqueInstrucciones -> { listaIntrucciones? }
ListaInstrucciones -> Instruccion ListaInstrucciones?

Instruccion -> Console | If | While | do | For | Asignacion
Asignacion -> Identificador = Expresion;

If -> if (Condicion) bloqueInstrucciones | instruccion
     (else bloqueInstrucciones | instruccion)?

Condicion -> Expresion operadorRelacional Expresion

While -> while(Condicion) bloqueInstrucciones | instruccion
Do -> do 
        bloqueInstrucciones | intruccion 
      while(Condicion);
For -> for(Asignacion Condicion; Incremento) 
       BloqueInstrucciones | Intruccion 
Incremento -> Identificador ++ | --

Console -> Console.(WriteLine|Write) (cadena); |
           Console.(Read | ReadLine) ();

Main      -> static void Main(string[] args) BloqueInstrucciones 

Expresion -> Termino MasTermino
MasTermino -> (OperadorTermino Termino)?
Termino -> Factor PorFactor
PorFactor -> (OperadorFactor Factor)?
Factor -> numero | identificador | (Expresion)*/       
    }
}