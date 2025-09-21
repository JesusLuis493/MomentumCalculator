namespace Myapp
{
    using System.Diagnostics;
    using Operations;
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
                Console.WriteLine("1. [Calcular Momentum X & Y]");
                Console.WriteLine("2. [Calcular componentes X & Y]");
                opc = int.Parse(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        long dX, dY;
                        Console.WriteLine("[Calcular Momentum X & Y]");
                        //distancia 
                        Console.WriteLine("[ingrese distancia en X (dX)]");
                        dX = long.Parse(Console.ReadLine());
                        Console.WriteLine("[ingrese distancia en Y (dY)]");
                        dY = long.Parse(Console.ReadLine());
                        //fuerza y angulo
                        long F, A;
                        Console.WriteLine("[ingrese fuerza ejercida (F)]");
                        F = long.Parse(Console.ReadLine());
                        Console.WriteLine("[ingrese angulo respecto al eje X (A)]");
                        A = long.Parse(Console.ReadLine());
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
                                    long H, A2;
                                    Console.WriteLine("[ingrese hipotenusa (H)]");
                                    H = long.Parse(Console.ReadLine());
                                    Console.WriteLine("[ingrese angulo respecto al eje X (A)]");
                                    A2 = long.Parse(Console.ReadLine());
                                    Console.WriteLine("[Componente en X de su fuerza es: {0} ]", obj.CompX(H, A2));
                                    Console.WriteLine("[Componente en Y de su fuerza es: {0} ]", obj.CompY(H, A2));
                                    break;
                                case 2:
                                    long catad, catop, hip1, Fh;
                                    Console.WriteLine("[Porfavor ingrese las medidas del mini-triangulo]");
                                    Console.WriteLine("[medida de hipotenusa]");
                                    hip1 = long.Parse(Console.ReadLine());
                                    Console.WriteLine("[medida de cateto opuesto]");
                                    catop = long.Parse(Console.ReadLine());
                                    Console.WriteLine("[medida de cateto adyasente]");
                                    catad = long.Parse(Console.ReadLine());
                                    Console.WriteLine("[ingresela fuerza]");
                                    Fh = long.Parse(Console.ReadLine());
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
                        Console.WriteLine("[grasias por usar este sistema :)]");
                        break;
                    default:
                        Console.WriteLine("[Opcion invalida]");
                        break;
                }
            } while (opc != 3);

        }
    }
}