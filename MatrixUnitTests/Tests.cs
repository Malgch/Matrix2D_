using MatrixLib;

namespace MatrixUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Matrix_Creation()
        {
            //Arrange
            var matrix = new Matrix2D(1, 2, 3, 4);

            //Act
            var a = matrix.A;
            var b = matrix.B;
            var c = matrix.C;
            var d = matrix.D;
            //Assert 
            Assert.That(1, Is.EqualTo(a));
            Assert.That(2, Is.EqualTo(b));
            Assert.That(3, Is.EqualTo(c));
            Assert.That(4, Is.EqualTo(d));
        }

        [Test]
        public void Creating_Identity_Matrix_method()
        {
            var matrix = new Matrix2D();
            matrix = Matrix2D.Id;

            Assert.That(1, Is.EqualTo(matrix.A));
            Assert.That(0, Is.EqualTo(matrix.B));
            Assert.That(0, Is.EqualTo(matrix.C));
            Assert.That(1, Is.EqualTo(matrix.D));
        }

        [Test]
        public void Parsing_matrix_ToString()
        {
            int a = 1; int b = 2; int c = 3;int d = 4;
            var matrix = new Matrix2D(1, 2, 3, 4);
            string test = matrix.ToString();

            Assert.That(($"[[1, 2 ], [3, 4 ]]"), Is.EqualTo(matrix.ToString()));
        }


        [Test]
        [TestCase(1,2,3, 4, 5, 6, 7, 8)]
        [TestCase(-1, -2, 3, 4, 5, 6, 7, 8)]
        public void Sum_matrixes(int x, int y, int z, int u, int a, int b, int c, int d)
        {
            var matrix_a = new Matrix2D(x, y, z, u);
            var matrix_b = new Matrix2D(a, b, c, d);
            var suma = matrix_a + matrix_b;

            Assert.That(x+a, Is.EqualTo(suma.A));
            Assert.That(y + b, Is.EqualTo(suma.B));
            Assert.That(z + c, Is.EqualTo(suma.C));
            Assert.That(u + d, Is.EqualTo(suma.D));
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5, 6, 7, 8)]
        [TestCase(-1, -2, 3, 4, 5, 6, 7, 8)]
        public void Substract_matrixes(int x, int y, int z, int u, int a, int b, int c, int d)
        {
            var matrix_a = new Matrix2D(x, y, z, u);
            var matrix_b = new Matrix2D(a, b, c, d);
            var suma = matrix_a - matrix_b;

            Assert.That(x - a, Is.EqualTo(suma.A));
            Assert.That(y - b, Is.EqualTo(suma.B));
            Assert.That(z - c, Is.EqualTo(suma.C));
            Assert.That(u - d, Is.EqualTo(suma.D));
        }

        [Test]
        [TestCase(1, 2, 3, 4, 5)]
        [TestCase(-1, -2, 3, 4, 5)]
        public void Scalar_multiplication(int x, int y, int z, int u, int a)
        {
            var matrix_a = new Matrix2D(x, y, z, u);
            var multiplication = a * matrix_a;

            Assert.That(a * matrix_a.A, Is.EqualTo(multiplication.A));
            Assert.That(a * matrix_a.B, Is.EqualTo(multiplication.B));
            Assert.That(a * matrix_a.C, Is.EqualTo(multiplication.C));
            Assert.That(a * matrix_a.D, Is.EqualTo(multiplication.D));
        }

        [Test]
        [TestCase(1, 2, 3, 4)]
        [TestCase(-1, -2, 3, 4)]
        public void Matrix_reciprocal(int x, int y, int z, int u)
        {
            var matrix_a = new Matrix2D(x, y, z, u);
            var reciprocal = -matrix_a;

            Assert.That(-1 * matrix_a.A, Is.EqualTo(reciprocal.A));
            Assert.That(-1 * matrix_a.B, Is.EqualTo(reciprocal.B));
            Assert.That(-1 * matrix_a.C, Is.EqualTo(reciprocal.C));
            Assert.That(-1 * matrix_a.D, Is.EqualTo(reciprocal.D));
        }

        [Test]
        [TestCase(1, 2, 3, 4)]
        [TestCase(-1, -2, 3, 4)]
        public void Matrix_transpose(int x, int y, int z, int u)
        {
            var matrix_a = new Matrix2D(x, y, z, u);
            var reciprocal = Matrix2D.Transpose(matrix_a);

            Assert.That(matrix_a.A, Is.EqualTo(reciprocal.A));
            Assert.That(matrix_a.B, Is.EqualTo(reciprocal.C));
            Assert.That(matrix_a.C, Is.EqualTo(reciprocal.B));
            Assert.That(matrix_a.D, Is.EqualTo(reciprocal.D));
        }

        [Test]
        [TestCase(1, 2, 3, 4)]
        [TestCase(-1, -2, 3, 4)]
        public void Matrix_determinant(int x, int y, int z, int u)
        {
            var matrix_a = new Matrix2D(x, y, z, u);
            var determinant = Matrix2D.Determinant(matrix_a);
            Assert.That(determinant, Is.EqualTo((matrix_a.A * matrix_a.D) - (matrix_a.B * matrix_a.C)));

        }


    }
}