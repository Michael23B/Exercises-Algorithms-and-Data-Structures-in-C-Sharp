using System;

namespace UnitTests
{
    //Dummy classes used during unit testing.
    class DummyClass
    {
        public DummyClass()
        {
            dummyData = "data";
        }

        public string DummyMethod()
        {
            return "method";
        }

        public string dummyData;
    }

    class DummyComparableClass : IComparable<DummyComparableClass>
    {
        public DummyComparableClass()
        {
            dummyData = GimmeRand.R.Next(10000);
        }

        public string DummyMethod()
        {
            return "method";
        }

        public int CompareTo(DummyComparableClass other)
        {
            return dummyData.CompareTo(other.dummyData);
        }

        public int dummyData;
    }


    //static class to get random values without instantiating a new Random every time
    public static class GimmeRand
    {
        public static Random R = new Random();
    }
}
