using MatrixLib;

//w poleceniach zadania "metoda klasy" to ma być public static
//Matrix2D m = new Matrix2D(1, 2, 3, 4); //
Matrix2D m = new();
Matrix2D p = new();


Console.WriteLine(p == m); //nie są równe, bo to jest porównywanie wartości referencyjnych
Console.WriteLine(p.Equals(m)); //jest True kiedy Matrix2D jest struct a nie class, lub trzeba zaimplemenować nowy Equals



