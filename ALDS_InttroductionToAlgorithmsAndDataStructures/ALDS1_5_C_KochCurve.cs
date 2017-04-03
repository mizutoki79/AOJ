using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
 
class Program{
    static void Main(){
        int n = int.Parse(Console.ReadLine());
        AOJ.Point p1 = new AOJ.Point(0.0, 0.0);
        AOJ.Point p2 = new AOJ.Point(100.0, 0.0);
        Console.WriteLine(p1.ToString());
        AOJ.Koch.KochCurve(p1, p2, n);
        Console.WriteLine(p2.ToString());
    }
}

namespace AOJ
{
    class Koch{
        static double rad60 = Math.PI * 60.0 / 180.0;

        public static void KochCurve(Point p1, Point p2, int depth){
            Point s = p1 + (p2 - p1) / 3.0;
            Point t = p2 + (p1 - p2) / 3.0;
            double ux = (t - s).X * Math.Cos(rad60) - (t - s).Y * Math.Sin(rad60) + s.X;
            double uy = (t - s).X * Math.Sin(rad60) + (t - s).Y * Math.Cos(rad60) + s.Y;
            Point u = new Point(ux, uy);
            if(depth-- > 0){
                KochCurve(p1, s, depth);
                Console.WriteLine(s.ToString());
                KochCurve(s, u, depth);
                Console.WriteLine(u.ToString());
                KochCurve(u, t, depth);
                Console.WriteLine(t.ToString());
                KochCurve(t, p2, depth);
            }
        }
        
    }

    class Point{
        public double X {get; set;}
        public double Y {get; set;}

        public Point(double x, double y){
            this.X = x;
            this.Y = y;
        }
        
        public static Point operator + (Point p1, Point p2){
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }
        public static Point operator - (Point p1, Point p2){
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
        public static Point operator / (Point p, double n){
            return new Point(p.X / n, p.Y / n);
        }
        public static Point operator * (Point p, double n){
            return new Point(p.X * n, p.Y * n);
        }

        public override string ToString(){
            return string.Format("{0:F8} {1:F8}", this.X, this.Y);
        }
    }
}