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


    }
}