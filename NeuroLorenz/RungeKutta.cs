using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuroLorenz
{
    class RungeKutta
    {
        static void RunCalculation()
        {
            //Incrementers to pass into the known solution
            double t = 0.0;
            double T = 10.0;
            double dt = 0.1;

            // Assign the number of elements needed for the arrays
            int n = (int)(((T - t) / dt)) + 1;

            // Initialize the arrays for the time index 's' and estimates 'y' at each index 'i'
            double[] y = new double[n];
            double[] s = new double[n];

            // RK4 Variables
            double dy1;
            double dy2;
            double dy3;
            double dy4;

            // RK4 Initializations
            int i = 0;
            s[i] = 0.0;
            y[i] = 1.0;

            Console.WriteLine(" ===================================== ");
            Console.WriteLine(" Beging 4th Order Runge Kutta Method ");
            Console.WriteLine(" ===================================== ");

            Console.WriteLine();
            Console.WriteLine(" Given the example Differential equation: \n");
            Console.WriteLine("     y' = t*sqrt(y) \n");
            Console.WriteLine(" With the initial conditions: \n");
            Console.WriteLine("     t0 = 0" + ", y(0) = 1.0 \n");
            Console.WriteLine(" Whose exact solution is known to be: \n");
            Console.WriteLine("     y(t) = 1/16*(t^2 + 4)^2 \n");
            Console.WriteLine(" Solve the given equations over the range t = 0...10 with a step value dt = 0.1 \n");
            Console.WriteLine(" Print the calculated values of y at whole numbered t's (0.0,1.0,...10.0) along with the error \n");
            Console.WriteLine();

            Console.WriteLine(" y(t) " + "RK4" + " ".PadRight(18) + "Absolute Error");
            Console.WriteLine(" -------------------------------------------------");
            Console.WriteLine(" y(0) " + y[i] + " ".PadRight(20) + (y[i] - solution(s[i])));

            // Iterate and implement the Rk4 Algorithm
            while (i < y.Length - 1)
            {

                dy1 = dt * equation(s[i], y[i]);
                dy2 = dt * equation(s[i] + dt / 2, y[i] + dy1 / 2);
                dy3 = dt * equation(s[i] + dt / 2, y[i] + dy2 / 2);
                dy4 = dt * equation(s[i] + dt, y[i] + dy3);

                s[i + 1] = s[i] + dt;
                y[i + 1] = y[i] + (dy1 + 2 * dy2 + 2 * dy3 + dy4) / 6;

                double error = Math.Abs(y[i + 1] - solution(s[i + 1]));
                double t_rounded = Math.Round(t + dt, 2);

                if (t_rounded % 1 == 0)
                {
                    Console.WriteLine(" y(" + t_rounded + ")" + " " + y[i + 1] + " ".PadRight(5) + (error));
                }

                i++;
                t += dt;

            };//End Rk4

            Console.ReadLine();
        }

        // Differential Equation
        public static double equation(double t, double y)
        {
            double y_prime;
            return y_prime = t * Math.Sqrt(y);
        }

        // Exact Solution
        public static double solution(double t)
        {
            double actual;
            actual = Math.Pow((Math.Pow(t, 2) + 4), 2) / 16;
            return actual;
        }
    }



    //our target

//    clc;
//      clear all;
//    sigm=10;
//bet=8/3;
//rh=28;
//f = @(t, a1, a2, a3)[-sigm * a1 + sigm * a2; rh* a1 - a2 - a1* a2; -bet* a3 + a1* a2];
//    t(1)=0;  %initializing x, y, z, t
//      x(1)=1;
//      y(1)=1;
//      z(1)=1;
//      sigma = 10;   %value of constants
//      rho = 28;
//    beta = (8 / 3);
//      h = 0.1;   %step size
//      t = 0:h:100;
//      g =@(t, x, y, z) x* rho-x.* z-y;
//      p =@(t, x, y, z) x.*y-beta* z;
//      for i=1:(length(t)-1) %loop
//      k1 = h * f(t(i), x(i), y(i), z(i));
//    l1 = h* g(t(i), x(i), y(i), z(i));
//    m1 = h* p(t(i), x(i), y(i), z(i));
//    k2 = h* f(t(i) + h, (x(i) + 0.5*k1), (y(i) + (0.5* l1)), (z(i) + (0.5* m1)));
//      l2 = h* f(t(i) + h, (x(i) + 0.5*k1), (y(i) + (0.5* l1)), (z(i) + (0.5* m1)));
//      m2 = h* f(t(i) + h, (x(i) + 0.5*k1), (y(i) + (0.5* l1)), (z(i) + (0.5* m1)));
//      k3 = h* f(t(i) + h, (x(i) + 0.5*k2), (y(i) + (0.5* l2)), (z(i) + (0.5* m2)));
//      l3 = h* f(t(i) + h, (x(i) + 0.5*k2), (y(i) + (0.5* l2)), (z(i) + (0.5* m2)));
//      m3 = h* f(t(i) + h, (x(i) + 0.5*k2), (y(i) + (0.5* l2)), (z(i) + (0.5* m2)));
//      k4 = h* f(t(i) + h, (x(i) + k3), (y(i) + l3), (z(i) + m3));
//      l4 = h* g(t(i) + h, (x(i) + k3), (y(i) + l3), (z(i) + m3));
//      m4 = h* p(t(i) + h, (x(i) + k3), (y(i) + l3), (z(i) + m3));
//      x(i+1)=x(i)+h* (1/6)* (k1+2* k2+2* k3+k4); %final equations
//      y(i+1)=y(i)+h* (1/6)* (k1+2* k2+2* k3+k4);
//      z(i+1)=z(i)+h* (1/6)* (m1+2* m2+2* m3+m4);
//      end
//      plot3(x, y, z)

}
