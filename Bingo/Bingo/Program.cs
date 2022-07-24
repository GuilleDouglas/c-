
var carton = new int[3, 9];
var genRandom= new Random(System.DateTime.Now.Millisecond);

Console.WriteLine("------------------------------Bingo de Douglas------------------------------");
for (int i = 0; i < 5; i++)
{
    //Generamos los numeros aleatorios para el carton 
    for (int c = 0; c < 9; c++)
    {
        for (int f = 0; f < 3; f++)
        {
            //En la condicion de la columna 1 se carga del 1-9
            //y en la columna 8 se carga desde el 0 hasta el 0
            int nuevoNumero = 0;
            //Para que entre en el bucle lo ponemos igual a false 
            bool encontreUnoNuevo = false;
            //Cuando encontro uno nuevo sale del bucle 
            while (!encontreUnoNuevo)
            {
                if (c == 0)
                {
                    //del 1 al 9
                    nuevoNumero = genRandom.Next(1, 10);
                }
                else if (c == 8)
                {
                    //del 80 al 90
                    nuevoNumero = genRandom.Next(80, 91);
                }
                //Todas las demas columnas
                else
                {
                    //Columnas del 2 al 8
                    nuevoNumero = genRandom.Next(c * 10, c * 10 + 10);
                }
                //Buscamos si el nuevoNumero existe en la columna
                encontreUnoNuevo = true;
                for (int f2 = 0; f2 < 3; f2++)
                {
                    if (carton[f2, c] == nuevoNumero)
                    {
                        encontreUnoNuevo = false;
                        break;
                    }
                }

                // Si salio del bucle y no encontro repetidos, esNuevo=true
            }

            carton[f, c] = nuevoNumero;
        }
    }

    //Esto es para ordenar las columnas de menor a mayor orden ascendente (Ordenamiento por burbuja)
    //Recorro columnas
    for(int c = 0; c < 9; c++)
    {
        //Recorro filas
        for(int f = 0; f < 3; f++)
        {
            //recorro la fila siguiente de la columna que estoy recorriendo
            for(int k=f+1; k<3; k++)
            {
                if (carton[f,c]> carton[k,c])
                {
                    //Hago un auxiliar donde guardo el valor actual de la posicion que apuntamos en la fila en dicha columna
                    int aux = carton[f,c];
                    //reemplazamos el valor de la fila siguiente en la actual 
                    carton[f,c]= carton[k,c];
                    //reemplazamos el valor de la fila en la posicion siguiente de la fila con el auxiliar
                    carton[k,c] = aux;
                }
            }
        }
    }
    var borrados = 0;

    //bucle while que de vueltas mientras no borramos 12 numeros
    while(borrados<12)
    {
        var filaABorrar = genRandom.Next(0, 3);
        var columnaABorrar = genRandom.Next(0, 9);
        if (carton[filaABorrar, columnaABorrar]==0)
        {
            //continue resetea al while, no hace lo que esta debajo 
            continue;
        }
        //contamos cuantos ceros hay en esta fila.
        var cerosEnFila = 0;
        for(int c=0; c<9;c++)
        {
            if(carton[filaABorrar,c]==0)
            { cerosEnFila++; }
        }
        //contamos cuantos ceros hay en esta columna
        var cerosEnColumna = 0;
        for (int f = 0; f < 3; f++)
        {
            if (carton[f, columnaABorrar] == 0)
            { cerosEnColumna++; }
        }
        //Contamos cuantos items tenemos en esta columna
        var itemsPorColumna = new int[9];
        for(int c=0; c<9;c++)
        { for(int f=0; f<3; f++)
            {
             if (carton[f,c]!=0)
                { 
                    itemsPorColumna[c]++;
                }
            }
        }

        // Contamos cuantas columnas hay con un solo numero
        var columnaConUnSoloNumero = 0;
        for(int c=0;c<9;c++)
        {
            if (itemsPorColumna[c]==1)
            {
                columnaConUnSoloNumero++; 
            }
        }
        //Si ya hay 4 ceros en la fila o si ya hay 2 ceros en la columna 
        //No se hago nada
        if (cerosEnFila == 4 || cerosEnColumna == 2)
            continue;

        //Si hay 3 columnas con 1 solo numero
        //se debe borrar las columnas que tienen 3 items
        if(columnaConUnSoloNumero ==3 && itemsPorColumna[columnaABorrar]!=3)
        { continue; }
        //Si no entro por las opciones anteriores borramos el numero
        carton[filaABorrar, columnaABorrar] = 0;
        borrados++;
    }



    //Mostrar carton por pantalla
    Console.WriteLine("-------------------------------------");
    for (int f = 0; f < 3; f++)
    {
        for (int c = 0; c < 9; c++)
        {
            if (c == 0)
                Console.Write("|");
            //Si es cero mostramos espacios
            if (carton[f, c] == 0)
                Console.Write("   |");
            else
                Console.Write($" {carton[f, c]:00}|");
        }
        Console.WriteLine();
    }

    Console.WriteLine("-------------------------------------");
    Console.WriteLine();

}

