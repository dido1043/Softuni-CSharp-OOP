using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get { return length; }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(Message.Error, nameof(this.Length)));
                }
                this.length = value;
            }
        }

        public double Width
        {
            get { return width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(Message.Error, nameof(this.Width)));
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format(Message.Error, nameof(this.Height)));
                }
                this.height = value;
            }
        }
        public double SurfaceArea()
        {
            return (2 * this.length * this.width) + (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.length * this.height) + (2 * this.width * this.height);
        }

        public double Volume()
        {
            return this.length * this.width * this.height;
        }

    }
}
