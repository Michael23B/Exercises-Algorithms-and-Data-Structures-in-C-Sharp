using PracticeQuestionsSharp.DataStructures;

//An animal shelter that operates on a first-in first-out basis housing only cats and dogs.
//Customers can request either a cat, a dog or any animal. They receive the oldest of that type.
//Implement a queue with the following operations: enqueue, dequeueAny, dequeueDog and dequeueCat.

namespace PracticeQuestionsSharp.Exercises
{
    public class QueueAnimalShelter
    {
        public QueueAnimalShelter()
        {
            cats = new Queue<ShelterAnimal>();
            dogs = new Queue<ShelterAnimal>();
            animalIndex = 0;
        }

        public QueueAnimalShelter Enqueue(string name, Species species)
        {
            var newAnimal = new ShelterAnimal(name, species, animalIndex++);

            if (newAnimal.Species == Species.Cat) cats.Enqueue(newAnimal);
            else dogs.Enqueue(newAnimal);

            return this;
        }

        public ShelterAnimal DequeueAny()
        {
            if (cats.IsEmpty) return dogs.Dequeue();
            if (dogs.IsEmpty) return cats.Dequeue();

            return dogs.Peek().ArrivalOrder < cats.Peek().ArrivalOrder ? dogs.Dequeue() : cats.Dequeue();
        }

        public ShelterAnimal DequeueCat()
        {
            return cats.Dequeue();
        }

        public ShelterAnimal DequeueDog()
        {
            return dogs.Dequeue();
        }

        public ShelterAnimal Peek()
        {
            if (cats.IsEmpty) return dogs.Peek();
            if (dogs.IsEmpty) return cats.Peek();

            return dogs.Peek().ArrivalOrder < cats.Peek().ArrivalOrder ? dogs.Peek() : cats.Peek();
        }

        public void Clear()
        {
            cats.Clear();
            dogs.Clear();
        }

        public bool IsEmpty => Count == 0;
        public bool IsCatsEmpty => cats.Count == 0;
        public bool IsDogsEmpty => dogs.Count == 0;
        public int Count => dogs.Count + cats.Count;

        private readonly Queue<ShelterAnimal> cats;
        private readonly Queue<ShelterAnimal> dogs;
        private int animalIndex;

        public enum Species { Cat, Dog }

        public class ShelterAnimal
        {
            public ShelterAnimal(string name, Species species, int index)
            {
                Name = name;
                Species = species;
                ArrivalOrder = index;
            }
            public string Name { get; }
            public Species Species { get; }
            public int ArrivalOrder { get; }
        }
    }
}
