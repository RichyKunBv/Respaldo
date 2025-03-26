abstract class Figura
{
    public abstract double CalcularPerimetro();
    public abstract double CalcularArea();
    public abstract string DeterminarTipo();
}

class CuadradoRectangulo : Figura
{
    public double Lado1 { get; set; }
    public double Lado2 { get; set; }

    public CuadradoRectangulo(double lado1, double lado2)
    {
        Lado1 = lado1;
        Lado2 = lado2;
    }

    public override double CalcularPerimetro()
    {
        return 2 * (Lado1 + Lado2);
    }

    public override double CalcularArea()
    {
        return Lado1 * Lado2;
    }

    public override string DeterminarTipo()
    {
        return Lado1 == Lado2 ? "Cuadrado" : "Rectángulo";
    }
}
