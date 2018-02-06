using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class EventsEcample
    {
    }

    public class Car
    {
        public int CurrentSpeed { get;  set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }

        private bool carIsDead { get; set; }

        public delegate void CarEngineHandler(string msgForCaller);
        private CarEngineHandler listOfHandlers;
        public Car()
        {
        }

        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }

        public void RegisterWithCarEngine(CarEngineHandler methodTocall)
        {
            listOfHandlers += methodTocall;
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
                listOfHandlers("Sorry car is dead");
            
        }
    }
}
