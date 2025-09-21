namespace Operations
{
    internal class Create
    {
        //clase de validacion 0
        public void validacion(long n)
        {
            if (n == 0)
            {
                Console.WriteLine("[falla de validacion, {0} no puedes ser 0]", n);
            }
        }
        //componentes x and y de la fuerza ejercida
        public double CompX(long F, long A)
        {
            double Fx = F * Math.Cos(A * Math.PI / 180);
            return (Fx);
        }
        public double CompY(long F, long A)
        {
            double Fy = F * Math.Sin(A * Math.PI / 180);
            return (Fy);
        }
        //momentum
        public double MomentoX(long dY, double Fx)
        {
            return (Fx * dY);
        }
        public double MomentoY(long dX, double Fy)
        {
            return (Fy * dX);
        }
        //Calculo por medio de triangulo
        public double ComponeteX(long Fh, long catad, long hip1)
        {
            //nota: no se puede hacer una divicion entre 2 longs
            double Fx = (Fh * ((double)catad / hip1));
            return (Fx);
        }
        public double ComponenteY(long Fh, long catop, long hip1)
        {
            double Fy = (Fh * ((double)catop / hip1));
            return (Fy);
        }
    }
}