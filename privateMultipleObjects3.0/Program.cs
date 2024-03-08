using System;
using System.ComponentModel.Design;
namespace late
{
    class Skaters
    {
        private string _Name;
        private string _Sponser;
        private int _Age;
        private string _Gender;

        public Skaters()
        {
            _Name = string.Empty;
            _Sponser = string.Empty;
            _Age = 0;
            _Gender = string.Empty;
        }
        public Skaters(string name, string sponser, int age, string gender)
        {
            _Name=name;
            _Sponser=sponser;
            _Age=age;
            _Gender=gender;
        }
        public string get_Name()
        { return _Name; }
        public string get_Sponser()
        {
            return _Sponser;
        }
        public int get_Age() { return _Age; }
        public string get_Gender() { return _Gender; }
        public void set_Name(string name) { _Name = name; }
        public void set_Sponser(string sponser) { _Sponser = sponser; }
        public void set_Age(int age) { _Age = age; }
        public void set_Gender(string gender) { _Gender = gender; }
        public virtual void addChange()
        {
            Console.WriteLine("Name - ");
            set_Name(Console.ReadLine());
            Console.WriteLine("Sponser - ");
            set_Sponser(Console.ReadLine());
            Console.WriteLine("Age - ");
            set_Age(int.Parse(Console.ReadLine()));
            Console.WriteLine("Gender - ");
            set_Gender(Console.ReadLine());
        }
        public virtual void print()
        {
            Console.WriteLine($" Name - {get_Name()}");
            Console.WriteLine($" Sponser - {get_Sponser()}");
            Console.WriteLine($" Age - {get_Age()}");
            Console.WriteLine($" Gender - {get_Gender()}");
        }
    }
    class Styles : Skaters
    {
        private string _Vert;
        private string _Street;
        private string _Hybrid;

        public Styles()
            : base()
        {
            _Vert = string.Empty;
            _Street = string.Empty;
            _Hybrid = string.Empty;
        }
        public Styles(string vert, string street, string hybrid)
            : base()
        {
            _Vert=vert;
            _Street=street;
            _Hybrid=hybrid;
        }
        public void set_Vert(string vert)
        {
            _Vert = vert;
        }
        public void set_Street(string street)
        {
            _Street = street;
        }
        public void set_Hybrid(string hybrid)
        {
            _Hybrid = hybrid;
        }
        public string get_Vert()
        {
            return _Vert;
        }
        public string get_Street()
        { return _Street; }
        public string get_Hybrid()
        { return _Hybrid; }
        public override void addChange()
        {
            base.addChange();
            Console.WriteLine("Vert - ");
            set_Vert(Console.ReadLine());
            Console.WriteLine("Street - ");
            set_Street(Console.ReadLine());
            Console.WriteLine("Hybrid - ");
            set_Hybrid(Console.ReadLine());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine($" Vert - {get_Vert()}");
            Console.WriteLine($" Street - {get_Street()}");
            Console.WriteLine($" Hybrid - {get_Hybrid()}");
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many skaters blud?");
            int maxSka;
            while (!int.TryParse(Console.ReadLine(), out maxSka))
                Console.WriteLine("Bruh enter a real number smhhh");
            Skaters[] ska = new Skaters[maxSka];
            Console.WriteLine("How many styles of skating?");
            int maxSty;
            while (!int.TryParse(Console.ReadLine(), out maxSty))
                Console.WriteLine("You're killing me smalls, enter something real!");
            Styles[] sty = new Styles[maxSty];
            int choice, rec, type;
            int skaCounter = 0, styCounter = 0;
            choice = Menu();
            while (choice != 4)
            {
                Console.WriteLine("1 for Skaters, 2 for Styles");
                while (!int.TryParse(Console.ReadLine(), out type))
                    Console.WriteLine("OMG bruh hit 1 or 2, skaters or styles..");
                try
                {
                    switch (choice)
                    {
                        case 1:
                            if (type == 1)
                            {
                                if (skaCounter <= maxSka)
                                {
                                    ska[skaCounter] = new Skaters();
                                    ska[skaCounter].addChange();
                                    skaCounter++;
                                }
                                else
                                    Console.WriteLine("Cannot add any more bruh!");

                            }
                            else
                            {
                                if (styCounter <= maxSty)
                                {
                                    sty[styCounter]= new Styles();
                                    sty[styCounter].addChange();
                                    styCounter++;
                                }
                                else
                                    Console.WriteLine("Cant put any more numbers blud");
                            }
                            break;
                        case 2:
                            Console.Write("1 to change skaters, 2 to change styles");
                            while (!int.TryParse(Console.ReadLine(), out rec))
                                Console.Write("Enter data you want changed");
                            rec--;
                            if (type == 1)
                            {
                                while (rec > skaCounter - 1 || rec < 0)
                                {
                                    Console.Write("invalid number dawg go again!");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter data you want changed ");
                                    rec--;
                                }
                                ska[rec].addChange();
                            }
                            else
                            {
                                while (rec > styCounter - 1 || rec < 0)
                                {
                                    Console.Write("Horrible number choice what else you got?");
                                    while (!int.TryParse(Console.ReadLine(), out rec))
                                        Console.Write("Enter data you want changed");
                                    rec--;
                                }
                                sty[rec].addChange();
                            }
                            break;
                        case 3:
                            if (type == 1)
                            {
                                for (int i = 0; i < skaCounter; i++)
                                    ska[i].print();
                            }
                            else
                            {
                                for (int i = 0; i < styCounter; i++)
                                    sty[i].print();
                            }
                            break;
                        default:
                            Console.WriteLine("You made an invalid selection, please try again");
                            break;
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                choice = Menu();

            }
        }

        private static int Menu()
        {
            Console.WriteLine("Select from the menu BLUD");
            Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            int selection = 0;
            while (selection < 1 || selection > 4)
                while (!int.TryParse(Console.ReadLine(), out selection))
                    Console.WriteLine("1-Add  2-Change  3-Print  4-Quit");
            return selection;
        }
    }
}
