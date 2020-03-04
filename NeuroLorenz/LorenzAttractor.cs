using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NeuroLorenz
{

    /**
* Interface to transform an object T to a derived form of object T. 
* @author G Cope
*
*/
    public interface Transform<T>
    {
        /**
         * Transforms and returns the transformation of the parameter val.
         * @param val The object to transform
         * @return The transformed object. Whether the returned value is the same or a different
         *  	instance than val is implementation specific.
         */
        public Func<T, T> Transform { get; set; }
    }
    /**
     * Class to store 3-dimensional values. 
     * @author G Cope
     *
     */
    public class Tuple3d
    {
        public double x;
        public double y;
        public double z;
        /**
         * Constructs a new Tuple class. 
         * @param x
         * @param y
         * @param z
         */
        public Tuple3d(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override string ToString()
        {
            return "[" + x + ":" + y + ":" + z + "]";
        }
    }
    /**
     * Attractor based upon the Lorenz equations
     * @author G Cope
     *
     */
    public class Lorenz : Transform<Tuple3d>
    {
        private Tuple3d current = new Tuple3d(0, 0, 0);
        private double a = 10d;
        private double b = 8d / 3d;
        private double c = 28d;
        private double dt = 0.01;
        /*
         * The Lorenz equations implemented as a Transform of a Tuple
         */



        //public Tuple3d transform(Tuple3d val)
        //{

        //}


        //Cumulative time.
        private double time = 0;

        public Func<Tuple3d, Tuple3d> Transform { get; set; }

        /**
* Construct a new object with an initial point at the origin and time change of 0.1
*/
        public Lorenz() : this(0, 0, 0)
        {
        }
        /**
         * Construct a new object with an initial point and default time change of 0.1
         * @param x
         * @param y
         * @param z
         */
        public Lorenz(double x, double y, double z) : this(x, y, z, 0.01)
        {
        }
        /**
         * Constructs a new object with an initial point and change in time
         * @param x
         * @param y
         * @param z
         * @param time
         */
        public Lorenz(double x, double y, double z, double deltaTime)
        {
            current = new Tuple3d(x, y, z);
            this.dt = deltaTime;

            Transform = (val) =>
            {
                //double dxdt = a * (val.y - val.x)*dt;
                //double dydt = (val.x * (c - val.z) - val.y)*dt;
                //double dzdt = (val.x * val.y - b * val.z);
                //double nx = val.x + dt * dxdt;
                //double ny = val.y + dt * dydt;
                //double nz = val.z + dt * dzdt;
                //return new Tuple3d(nx, ny, nz);
                double d0_x = a * (val.y - val.x) * dt/2;
                double d0_y = (-val.x * val.z + c * val.x - val.y) * dt/2;
                double d0_z = (val.x * val.y - b * val.z) * dt/2;
                double xt = val.x + d0_x;
                double yt = val.y + d0_y;
                double zt = val.z + d0_z;
                double d1_x = (a * (yt - xt)) * dt/2;
                double d1_y = (-xt * zt + c * xt - yt) * dt/2;
                double d1_z = (xt * yt - b* zt ) * dt/2;
                xt = val.x + d1_x;
                yt = val.y + d1_y;
                zt = val.z + d1_z;
                double d2_x = (a * (yt - xt)) * dt;
                double d2_y = (-xt * zt + c * xt - yt) * dt;
                double d2_z = (xt * yt - b * zt) * dt;
                xt = val.x + d2_x;
                yt = val.y + d2_y;
                zt = val.z + d2_z;
                double d3_x = (a * (yt - xt)) * dt/2;
                double d3_y = (-xt * zt + c * xt - yt) * dt/2;
                double d3_z = (xt * yt - b * zt) * dt/2;
                double old_y = val.y;
                double resx = val.x + (d0_x + d1_x + d1_x + d2_x + d3_x) * 0.33333333;
                double resy = val.y + (d0_y + d1_y + d1_y + d2_y + d3_y) * 0.33333333;
                double resz = val.z + (d0_z + d1_z + d1_z + d2_z + d3_z) * 0.33333333;

                return new Tuple3d(resx, resy, resz);
            };
        }
        public void setTransform(Func<Tuple3d, Tuple3d> transform)
        {
            this.Transform = transform;
        }
        /**
         * Gets the current cumulative time.
         * @return
         */
        public double getCurrentTime()
        {
            return time;
        }
        /**
         * Sets the delta time parameter
         * @param dt
         */
        public void setDt(double dt)
        {
            this.dt = dt;
        }
        /**
         * Iterates one step forward in time.
         */
        public void Iterate()
        {
            time += dt;
            current = Transform?.Invoke(current);
        }
        /**
         * Retrieves the current location. 
         * @return
         */
        public Tuple3d GetCurrentLocation()
        {
            return current;
        }
    }

}
