class Triangulo : Figura
{
    public double Lado1 { get; set; }
    public double Lado2 { get; set; }
    public double Lado3 { get; set; }

    public Triangulo(double lado1, double lado2, double lado3)
    {
        Lado1 = lado1;
        Lado2 = lado2;
        Lado3 = lado3;
    }

    public override double CalcularPerimetro()
    {
        return Lado1 + Lado2 + Lado3;
    }

    public override double CalcularArea()
    {
        double semiPerimetro = CalcularPerimetro() / 2;
        return Math.Sqrt(semiPerimetro * (semiPerimetro - Lado1) * (semiPerimetro - Lado2) * (semiPerimetro - Lado3));
    }

    public override string DeterminarTipo()
    {
        if (Lado1 == Lado2 && Lado2 == Lado3)
            return "Equilátero";
        else if (Lado1 == Lado2 || Lado2 == Lado3 || Lado1 == Lado3)
            return "Isósceles";
        else
            return "Escaleno";
    }
}
