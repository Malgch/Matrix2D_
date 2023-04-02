using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public class Matrix2D : IEquatable<Matrix2D>
    {
        public int A { get; init; } //set jest zablokowane-> metoda "readonly struct"
        public int B { get; init; }
        public int C { get; init; }
        public int D { get; init; }

        public Matrix2D(int a, int b, int c, int d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public Matrix2D() : this(1, 0, 0, 1) { }//odwołanie do konstruktora wyżej -> stworzenie macierzy jednostkowej

        public static readonly Matrix2D Id = new Matrix2D(1, 0, 0, 1); //nowa macierz jednostkowa, tylko do odczytu - po prawej Matrix2D można nie pisać
        public static readonly Matrix2D Zero = new(0, 0, 0, 0);

        public override string ToString() => $"[[{A}, {B} ], [{C}, {D} ]]";

        #region ==== Equals ====
        public bool Equals(Matrix2D? other) //implementacja interfejsu-> porównuje Matrix2D z czymś other // Equals nie może wyrzucać żadnych wyjątków bo cały kod będzie do dupy
        {
            if (other is null) return false; //zabezpieczenie przed wartością null, bo kontekst nullable jest włączony w projekcie i może być wartość null
            if (ReferenceEquals(this, other)) return true;//referencyjne porownanie obiektów - badanie wszystkich składników 2 obiektów - może tej linijki nie być, a tylko 
            //ta na dole, ale ReferenceEquals optymalizuje

            return A == other.A && B == other.B && C == other.C && D == other.D; //sprawdzanie czy liczby są takie same
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false; //is działa trochę inaczej niż == 
            if (obj is not Matrix2D) return false; //sprawdzamy czy obiekt jest macierzą

            return Equals(obj as Matrix2D); // (Matrix2D)obj - rzutowanie na typ Matrix2D, żeby kompilator wiedział o który Equals chodzi // to co jest w kodzie zapisane znaczy to samo
        }

        public override int GetHashCode() => HashCode.Combine(A, B, C, D);
        //hashCode to taki identyfikator obiektu, więcej o tym będzie na algorytmice

        #endregion

        public static bool operator ==(Matrix2D? left, Matrix2D? right) //musi być użyty is, bo inaczej będzie rekurencja
        {
            if (left is null && right is null) return true; //nulle są sobie równe!
            if (left is null) return false;

            return left.Equals(right);
        }
        public static bool operator !=(Matrix2D? left, Matrix2D? right) => !(left == right);

        #region dodwanie
        public static Matrix2D operator +(Matrix2D a, Matrix2D b)
        {
            var suma = new Matrix2D(a.A + b.A, a.B + b.B, a.C + b.C, a.D + b.D);
            return suma;
        }
        #endregion

        #region odejmowanie
        public static Matrix2D operator -(Matrix2D a, Matrix2D b)
        {
            var substract = new Matrix2D(a.A - b.A, a.B - b.B, a.C - b.C, a.D - b.D);
            return substract;
        }
        #endregion

        public static Matrix2D operator *(int k, Matrix2D b)
        {
            var scalar_multiply = new Matrix2D(k * b.A, k * b.B, k * b.C, k * b.D);
            return scalar_multiply;
        }

        public static Matrix2D operator *(Matrix2D b, int k)
        {
            var scalar_multiply = new Matrix2D(b.A * k, b.B * k, b.C * k, b.D * k);
            return scalar_multiply;
        }

        public static Matrix2D operator -(Matrix2D a)
        {
            var reciprocal = new Matrix2D(-a.A, -a.B, -a.C, -a.D);
            return reciprocal;
        }
    }
}
