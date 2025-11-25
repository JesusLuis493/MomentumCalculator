namespace Myapp
{
    using System.Diagnostics;
     using MomentumCalculator.CORE
    using Operations;
    using MomentumCalculator.Core;
    internal class Program
    {
        static void Main(string[] args)
        {
            int opc;
            //base
            Create obj = new Create();
            Console.WriteLine("[Bienvenido]");
            Console.WriteLine("[Proporcione los siguientes datos]");
            do
            {
                Console.WriteLine("1. [Calcular Momentum X & Y conociendo el angulo]");
                Console.WriteLine("2. [Calcular componentes X & Y]");
                Console.WriteLine("3. [Calcular Momentum X & Y conociendo componentes x & y de la fuerza]");
                Console.WriteLine("4. [calcular angulo de furza resultante]");
                Console.WriteLine("5. [Salir]");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        double dX, dY;
                        Console.WriteLine("[Calcular Momentum X & Y]");
                        //distancia 
                        Console.WriteLine("[ingrese distancia en X (dX)]");
                        dX = double.Parse(Console.ReadLine());
                        Console.WriteLine("[ingrese distancia en Y (dY)]");
                        dY = double.Parse(Console.ReadLine());
                        //fuerza y angulo
                        double F, A;
                        Console.WriteLine("[ingrese fuerza ejercida (F)]");
                        F = double.Parse(Console.ReadLine());
                        obj.validacion(F);
                        Console.WriteLine("[ingrese angulo respecto al eje X (A)]");
                        A = double.Parse(Console.ReadLine());
                        //resultados
                        Console.WriteLine("[Resultados]");
                        Console.WriteLine("[Componente en X de su fuerza es: {0} ]", obj.CompX(F, A));
                        Console.WriteLine("[Componente en Y de su fuerza es: {0} ]", obj.CompY(F, A));
                        //momentum x and y
                        Console.WriteLine("[El momentum en X es: {0}] ", obj.MomentoX(dY, obj.CompX(F, A)));
                        Console.WriteLine("[El momentum en Y es: {0}] ", obj.MomentoY(dX, obj.CompY(F, A)));                        
                        break;

                    case 2:
                        int opc2 = 0;
                        Console.WriteLine("[Calcular componentes en X & Y]");
                        do
                        {
                            Console.WriteLine("1. [Calcular por medio de angulo e hipotenusa]");
                            Console.WriteLine("2. [Calcular por medio de otro triangulo]");
                            Console.WriteLine("3. [Salir]");
                            opc2 = int.Parse(Console.ReadLine());
                            switch (opc2)
                            {
                                case 1:
                                    double H, A2;
                                    Console.WriteLine("[ingrese hipotenusa (H)]");
                                    H = double.Parse(Console.ReadLine());
                                    obj.validacion(H);
                                    Console.WriteLine("[ingrese angulo respecto al eje X (A)]");
                                    A2 = double.Parse(Console.ReadLine());
                                    Console.WriteLine("[Componente en X de su fuerza es: {0} ]", obj.CompX(H, A2));
                                    Console.WriteLine("[Componente en Y de su fuerza es: {0} ]", obj.CompY(H, A2));
                                    break;
                                case 2:
                                    double catad, catop, hip1, Fh;
                                    Console.WriteLine("[Porfavor ingrese las medidas del mini-triangulo]");
                                    Console.WriteLine("[medida de hipotenusa]");
                                    hip1 = double.Parse(Console.ReadLine());
                                    obj.validacion(hip1);
                                    Console.WriteLine("[medida de cateto opuesto]");
                                    catop = double.Parse(Console.ReadLine());
                                    obj.validacion(catop);
                                    Console.WriteLine("[medida de cateto adyasente]");
                                    catad = double.Parse(Console.ReadLine());
                                    obj.validacion(catad);
                                    Console.WriteLine("[ingresela fuerza]");
                                    Fh = double.Parse(Console.ReadLine());
                                    obj.validacion(Fh);
                                    //resulucion
                                    Console.WriteLine("[el componente FX es igual a {0}]", obj.ComponeteX(Fh, catad, hip1));
                                    Console.WriteLine("[el componente FY es igual a {0}]", obj.ComponenteY(Fh, catop, hip1));
                                    break;
                                case 3:
                                    Console.WriteLine("[bye bye]");
                                    break;
                                default:
                                    Console.WriteLine("[Opcion invalida]");
                                    break;
                            }
                        } while (opc2 != 3);
                        break;
                    case 3:
                        double disX, disY;
                        Console.WriteLine("[Calcular Momentum X & Y]");
                        //distancia 
                        Console.WriteLine("[ingrese distancia en X (dX)]");
                        disX = double.Parse(Console.ReadLine());
                        Console.WriteLine("[ingrese distancia en Y (dY)]");
                        disY = double.Parse(Console.ReadLine());
                        //componentes
                        double comX, comY;
                        Console.WriteLine("[ingrese componete en X (dX)]");
                        comX = double.Parse(Console.ReadLine());
                        Console.WriteLine("[ingrese componente en Y (dY)]");
                        comY = double.Parse(Console.ReadLine());
                        //momentum x and y
                        Console.WriteLine("[El momentum en X es: {0}] ", obj.MomentoX(disY, comX));
                        Console.WriteLine("[El momentum en Y es: {0}] ", obj.MomentoY(disX, comY));                        
                        break;
                    case 4:
                        double Frx, Fry;
                        Console.WriteLine("[Calcular angulo de fuerza resultante]");
                        //componentes
                        Console.WriteLine("[Ingrese su componene en x de su furza resultante]");
                        Frx = double.Parse(Console.ReadLine());
                        Console.WriteLine("[Ingrese su componene en y de su furza resultante]");
                        Fry = double.Parse(Console.ReadLine());
                        //angulo
                        Console.WriteLine("[El angulo resultante de su fuerza es {0} grados]", obj.angulo(Frx, Fry));
                        break;
                    case 5:
                        Console.WriteLine("[bye bye]");
                        break;
                    default:
                        Console.WriteLine("[Opcion invalida]");
                        break;
                }
            } while (opc != 5);

        }
    }

}
