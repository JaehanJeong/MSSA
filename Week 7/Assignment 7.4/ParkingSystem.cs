using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_7._4
{
    public enum CarType
    {
        Small = 1, // Smoll
        Medium = 2, // Medium
        Large = 3 // Big
    }

    public class ParkingSystem
    {
        public int SmallAvailableParking {  get; set; }
        public int MediumAvailableParking { get; set; }
        public int LargeAvailableParking { get; set; }

        public ParkingSystem(int smallAvailableParking, int mediumAvailableParking, int  largeAvailableParking)
        {
            SmallAvailableParking = smallAvailableParking;
            MediumAvailableParking = mediumAvailableParking;
            LargeAvailableParking = largeAvailableParking;
        }

        public bool AddCar(CarType carType)
        {
            switch(carType)
            {
                case CarType.Small:
                    if(SmallAvailableParking > 0)
                    {
                        SmallAvailableParking--;
                        return true;
                    }
                    break;
                case CarType.Medium:
                    if(MediumAvailableParking > 0)
                    {
                        MediumAvailableParking--;
                        return true;
                    }
                    break;
                case CarType.Large:
                    if(LargeAvailableParking > 0)
                    {
                        LargeAvailableParking--;
                        return true;
                    }
                    break;

            }
            return false;
        }


    }
}
