using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomaticGameLevelGeneration
{
    public class ApplicationLogic
    {
        public void Execute()
        {
            List<Individ> individs = new List<Individ>();
            for (int i = 0; i < 100; i++)
            {
                var individ = new Individ(1);

                individs.Add(individ);
            }

            int generationNumber = 0;
            int maxGenerationNumber = 50;
            while (generationNumber < maxGenerationNumber)
            {
                //crossover
                List<Individ> crossover = new List<Individ>();
                for (int i = 0; i < 50; i++)
                {
                    var p1 = individs[Singletons.RandomInstance.Next(100)];
                    var p2 = individs[Singletons.RandomInstance.Next(100)];
                    crossover.Add(p1.Crossover(p2, Singletons.RandomInstance.Next(100)));
                }

                //mutation
                List<Individ> mutated = new List<Individ>();
                for (int i = 0; i < 50; i++)
                {
                    var individ = individs[Singletons.RandomInstance.Next(100)];
                    mutated.Add(individ.Mutate());
                }

                //fitness eval
                List<Individ> potentialNewPopulation = new List<Individ>();
                potentialNewPopulation.AddRange(individs);
                potentialNewPopulation.AddRange(crossover);
                potentialNewPopulation.AddRange(mutated);

                var ff = new FitnessFunction();
                foreach (var individ in potentialNewPopulation)
                {
                    individ.fitness = (float?)ff.EvaluateIndividual(individ);
                }

                //choose new population
                IOrderedEnumerable<Individ> ordered = potentialNewPopulation.OrderBy(i => i.fitness);

                individs = ordered.ToList().GetRange(0, 100);

                generationNumber++;
            }
        }
    }
}