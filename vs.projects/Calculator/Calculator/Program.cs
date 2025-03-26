/*using System;

class Calculator
{
    private double _value_x;
    private double _value_y;

    public Calculator()
    {
        this._value_x = 0;
        this._value_y = 0;
    }

    public Calculator(double x, double y)
    {
        this._value_x = x;
        this._value_y = y;
    }

    public double value_x 
    {
        set
        {
            this._value_x = value;
        }
        get
        {
            return this._value_x; //return solo en get
        }
    }

    public double value_y
    {
        set
        {
            this._value_y = value;
        }
        get
        {
            return this._value_y;
        }
    }

    public double GetSum()
    {
        return this._value_x + this._value_y;
    }
}

public class Program
{
    public static void Main()
    {
 /*       Calculator C; //declaracion
        C = new Calculator(/*4, 0.25*/ //); //enstancia ; llama al constructor
/* C.value_x = 10;
 Console.WriteLine(C.GetSum());

 Console.ReadKey();
 /*C = null;*/ //limpieza para reutilizar la variable(bazur4)
               //constructor se debe llamar igual que la variable, sin argumentos 
               //  }
               //}

using System;

class Calculator
{
        private double _value_x;
        private double _value_y;

    public Calculator()
    {
        this._value_x = 0;
        this._value_y = 0;
    }

    public Calculator(double x, double y)
    {
        this._value_x = x;
        this._value_y = y;
    }

    public double value_x
    {
        set
        {
            this._value_x = value;
        }
        get
        {
            return this._value_x;
        }
    }

    public double value_y
    {
        set
        {
            this._value_y = value;
        }
        get
        {
            return this._value_y;
        }
    }

    public double GetSum()
    {
        return this._value_x + this._value_y;
    }
}

public class Program
{
    public static void Main()
    {
        Calculator C;
        C = new Calculator(4, 0.25);
        //C.value_x = 10;
        Console.WriteLine(C.GetSum());

        Console.ReadKey();
    }
}
