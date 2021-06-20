using System;
using System.Collections;
using System.Collections.Generic;

namespace FlaviusJosephusTask
{
    /// <summary>
    /// Class which solve Flavius Josephus task.
    /// </summary>
    public static class FlaviusJosephusTaskSolver
    {
        /// <summary>
        /// Solves the Flavius Josephus task and return number of last survive people.
        /// </summary>
        /// <param name="count">The count of people in the circle.</param>
        /// <param name="step">Step which describe how much people will be skipped before one of this will crossed out.</param>
        /// <returns>The number of survivor people.</returns>
        public static int Solve(int count, int step)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count of people can't be lower than one.");
            }

            if (step > count)
            {
                throw new ArgumentException("Step can't be greater than count of people.");
            }

            int lastSurviveNumber = default;

            foreach (var people in IterationOverCircle(count, step))
            {
                lastSurviveNumber = people;
            }

            return lastSurviveNumber;
        }

        /// <summary>
        /// Solves the Flavius Josephus task and return sequence of operation to remove from circle.
        /// </summary>
        /// <param name="count">The count of people in the circle.</param>
        /// <param name="step">Step which describe how much people will be skipped before one of this will crossed out.</param>
        /// <returns>The sequence of operation to remove from circle.</returns>
        public static IEnumerable<int> SolveWithSequence(int count, int step)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count of people can't be lower than one.");
            }

            if (step > count)
            {
                throw new ArgumentException("Step can't be greater than count of people.");
            }

            return IterationOverCircle(count, step);
        }

        private static IEnumerable<int> IterationOverCircle(int count, int step)
        {
            var cirule = new BitArray(count, true);
            int alive = cirule.Count;
            int index = step - 1;
            int skipped = default;

            RemoveFromCircle(cirule, index, ref skipped, ref alive);
            yield return index + 1;

            while (alive != 0)
            {
                if (index >= cirule.Length)
                {
                    index -= cirule.Length;
                }

                for (; index < cirule.Length; index++)
                {
                    if (cirule[index] && ++skipped == step)
                    {
                        RemoveFromCircle(cirule, index, ref skipped, ref alive);
                        yield return index + 1;
                    }
                }
            }

            void RemoveFromCircle(BitArray source, int index, ref int skipped, ref int alive)
            {
                source[index] = false;
                alive--;
                skipped = default;
            }
        }
    }
}
