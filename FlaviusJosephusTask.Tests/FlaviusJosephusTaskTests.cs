using System;
using System.Collections.Generic;
using NUnit.Framework;
using static FlaviusJosephusTask.FlaviusJosephusTaskSolver;

namespace FlaviusJosephusTask.Tests
{
    [TestFixture]
    internal class Tests
    {
        [Category("Exception tests")]
        [TestCase(0)]
        [TestCase(-1)]
        public void Solve_CountLowerThanOne_ThrowArgumentException(int count) => Assert.Throws<ArgumentException>(() => Solve(count, 1));

        [Category("Exception tests")]
        [TestCase(2)]
        [TestCase(100)]
        public void Solve_StepGreaterThanCount_ThrowArgumentException(int step) => Assert.Throws<ArgumentException>(() => Solve(1, step));

        [Category("Result tests")]
        [TestCase(100, 10, ExpectedResult = 26)]
        [TestCase(10, 2, ExpectedResult = 5)]
        [TestCase(20, 3, ExpectedResult = 20)]
        [TestCase(55, 17, ExpectedResult = 40)]
        [TestCase(100, 8, ExpectedResult = 97)]
        [TestCase(33, 2, ExpectedResult = 3)]
        [TestCase(1000, 5, ExpectedResult = 763)]
        public int Solve_ValidData_ReturnLastSurvivor(int count, int step) => Solve(count, step);

        private static IEnumerable<TestCaseData> SolveWithSequenceDataSource
        {
            get
            {
                yield return new TestCaseData(10, 2, new[] { 2, 4, 6, 8, 10, 3, 7, 1, 9, 5 });
                yield return new TestCaseData(20, 3, new[] { 3, 6, 9, 12, 15, 18, 1, 5, 10, 14, 19, 4, 11, 17, 7, 16, 8, 2, 13, 20 });
                yield return new TestCaseData(33, 2, new[] 
                { 
                    2, 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 1, 5, 9, 13, 
                    17, 21, 25, 29, 33, 7, 15, 23, 31, 11, 27, 19, 3 
                });
                yield return new TestCaseData(100, 10, new[] 
                { 
                    10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 11, 22, 33, 44, 55, 66, 77, 88, 
                    99, 12, 24, 36, 48, 61, 73, 85, 97, 9, 25, 38, 52, 65, 79, 93, 6, 21, 37, 53, 68, 83, 98, 15, 31, 47, 64, 82, 1, 17, 
                    35, 56, 74, 92, 13, 32, 54, 75, 95, 18, 42, 63, 87, 8, 39, 62, 89, 16, 45, 72, 3, 29, 67, 96, 28, 69, 4, 43, 81, 23, 
                    59, 7, 57, 5, 58, 19, 78, 41, 2, 84, 51, 46, 34, 49, 76, 94, 71, 27, 91, 14, 86, 26 
                });
            }
        }

        [Category("Sequence tests")]
        [TestCaseSource(nameof(SolveWithSequenceDataSource))]
        public void SolveWithSequenceTests(int count, int step, int[] expected)
        {
            var sequence = SolveWithSequence(count, step);
            CollectionAssert.AreEquivalent(expected, sequence);
        }
    }
}
