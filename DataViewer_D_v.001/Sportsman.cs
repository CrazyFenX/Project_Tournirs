using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class Sportsman
    {
        public string Name;
        public string Surname;
        public string Patronymic;

        public MyDate BirthDate = new MyDate();

        public int BookNumber;

        public string ClubName;
        public string City;

        public Trainer OlderTrainer = new Trainer();

        public string AgeCategory;
        public string SportClass;

        public string SportCategory;

        public Sportsman() //Constructor
        { 
            //pass
        }

        ~Sportsman()    //Destructor
        {
            //pass
        }
    }
}
