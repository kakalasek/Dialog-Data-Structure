namespace Dialog_Data_Structure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dialog dial = new Dialog("Ho, traveller. Where are you heading?");
            Dialog westDial = new Dialog("West, traveller. Be careful, those are dangerous places.");
            Dialog eastDial = new Dialog("Be careful watcha saying mofo. Wanna start a figt?");
            dial.AddOption("Nowhere, Feck off", null);
            dial.AddOption("West, my friend", westDial);
            dial.AddOption("East, dumbass", eastDial);
            eastDial.AddOption("Sorry, Ill be on my way", null);
            eastDial.AddOption("Try me, Bitch!", null);

            Console.WriteLine(dial.Text + "\n");
            foreach (var option in dial.Options)
            {
                Console.WriteLine(option.Key);
            }
            Console.WriteLine();

            Console.WriteLine(dial.Options["West, my friend"].Text + "\n");

           
        }
    }
}