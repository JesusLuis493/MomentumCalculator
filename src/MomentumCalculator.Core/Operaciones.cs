namespace Operations
{
    public class Create
    {
        //clase de validacion 0
        public void validacion(double n)
        {
            if (n == 0)
            {
                Console.WriteLine("[falla de validacion, {0} no puedes ser 0]", n);
            }
        }
        //componentes x and y de la fuerza ejercida
        public double CompX(double F, double A)
        {
            double Fx = F * Math.Cos(A * Math.PI / 180);
            return (Fx);
        }
        public double CompY(double F, double A)
        {
            double Fy = F * Math.Sin(A * Math.PI / 180);
            return (Fy);
        }
        //momentum
        public double MomentoX(double dY, double Fx)
        {
            return (Fx * dY);
        }
        public double MomentoY(double dX, double Fy)
        {
            return (Fy * dX);
        }
        //Calculo por medio de triangulo
        public double ComponeteX(double Fh, double catad, double hip1)
        {
            //nota: no se puede hacer una divicion entre 2 longs
            double Fx = (Fh * ((double)catad / hip1));
            return (Fx);
        }
        public double ComponenteY(double Fh, double catop, double hip1)
        {
            double Fy = (Fh * ((double)catop / hip1));
            return (Fy);
        }
        public double angulo (double Frx, double Fry)
        {
            double ang = Math.Atan(Fry / Frx) * (180 / Math.PI);
            return (ang);
        }
    }
}