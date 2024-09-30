namespace Triangle
{
    internal class UseTriangle
    {
        private double side_a;
        private double side_b;
        private double side_c;

        public double getPerimeter()
        {
            return this.side_a + this.side_b + this.side_c;
        }

        private double getSemiPerimeter()
        {
            return this.getPerimeter() / 2.0;
        }

        public double getArea()
        {
            double semi = this.getSemiPerimeter();
            double area = semi * (semi - this.side_a) + 
                          (semi - this.side_b) + 
                          (semi - this.side_c);
            return area;
        }

        public bool isATriangle()
        {
            if(this.side_a + this.side_b > this.side_c &&
               this.side_b + this.side_c > this.side_a &&
               this.side_a + this.side_c > this.side_b)
                return true;
            return false;
        }

        public string getNameTriangle()
        {
            if (this.side_a == this.side_b && this.side_b == this.side_c)
                return "Equilatero";
            else if (this.side_a != this.side_b && this.side_b != this.side_c)
                return "Escaleno";
            return "Isosceles";
        }

        public void setValueSideA(double value)
        {
            this.side_a = value;
        }
        public void setValueSideB(double value)
        {
            this.side_b = value;
        }
        public void setValueSideC(double value)
        {
            this.side_c = value;
        }
    }
}