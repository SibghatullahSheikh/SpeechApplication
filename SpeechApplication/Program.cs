
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;
using System.Speech.Recognition;

namespace SpeechApplication
{

    class Variables
    {
        public float bill = 0;
        public String size = "\n";
        public String toppings = " cheese";
        public int toppings_count = 0;
        public int size_flag = 0;
        public int toppings_flag = 0;
        public int repeat = 1;
    }

    class Speech
    {

        //Create an object var for class variables
        private static Variables vars = new Variables();

        static void Main(string[] args)
        {
            // Create an in-process speech recognizer for the en-US locale.
            using (
                SpeechRecognitionEngine recognizer =
                    new SpeechRecognitionEngine(
                        new System.Globalization.CultureInfo("en-US")))
            {

                Grammar PizzaGrammar = new Grammar(@"PizzaOrder.xml");
                PizzaGrammar.Name = "SRGS File Pizza Grammar";
                // Create and load a grammar.
                recognizer.LoadGrammar(PizzaGrammar);

                Console.WriteLine("Thanks for choosing Steven's Pizza Delivery System ");
                Console.WriteLine("The system requires politeness.");
                Console.WriteLine("You can leave at any time by saying exit.");
                Console.WriteLine("How can I help you?");
                Speak("Thanks for choosing Steven's Pizza Delivery System ");
                Speak("The system requires politeness.");
                Speak("You can leave at any time by saying exit.");
                Speak("How can I help you?");

                // Add a handler for the speech recognized event.
                recognizer.SpeechRecognized +=
                new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                // Configure input to the speech recognizer.
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.
                recognizer.RecognizeAsync(RecognizeMode.Multiple);


                // Keep the console window open.
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        // Handle the SpeechRecognized/ event.
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String s = e.Result.Text;
            int index;
            char[] separators = new char[] { ' ' };
            String[] words = s.Split(separators);
            String toppings = " ";
            int length = words.Length;


            for (index = 0; index < length; index++)
            {
                if (words[index][0] >= 'A' && words[index][0] <= 'Z')
                {
                    if ((String.Equals(words[index], "Small")) || (String.Equals(words[index], "Medium")) || (String.Equals(words[index], "Large")))
                    {
                        vars.size_flag = 1;
                        vars.size = words[(index)];

                    }

                    else if ((String.Equals(words[index], "Yes")) || (String.Equals(words[index], "Yeah")))
                    {
                        vars.bill = calculate(vars.size, vars.toppings_count);
                        Console.WriteLine("Your total bill amount is " + vars.bill + "$. And your order is placed.");
                        Speak("Your total bill amount is " + vars.bill + "$. And your order is placed.");
                        Environment.Exit(0);
                    }
                    else if ((String.Equals(words[index], "No")) || (String.Equals(words[index], "Nope")))
                    {

                        vars.toppings = " cheese ";
                        vars.size = "\n";
                        vars.size_flag = 0;
                        vars.toppings_count = 0;
                        Console.WriteLine("Sorry! Please place your order again!");
                        Speak("Sorry! Please place your order again!");
                    }
                    else if ((String.Equals(words[index], "Exit")))
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        vars.toppings += " ";
                        vars.toppings += words[index];
                        vars.toppings_count++;
                        

                    }
                }
            }

            if (vars.size_flag == 0)
            {
                Console.WriteLine("What size pizza would you like and what kind of toppings?");
                Speak("What size pizza would you like and what kind of toppings?");
            }

            if (vars.size_flag == 1 && vars.repeat % 2 != 0)
            {
                //vars.size_flag = 0;
                Console.WriteLine("You ordered for a " + vars.size + " pizza with" + vars.toppings + " Is that correct?");
                Speak("You ordered for a " + vars.size + "pizza with" + vars.toppings + ". Is that correct?");
            }

            vars.repeat++;
        }


        static void Speak(string text)
        {
            SpVoice voice = new SpVoiceClass();
            voice.Speak(text, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        //Calculates the total bill amount based on the size and number of toppings
        static float calculate(string size, int toppings)
        {
            float totalprice = 0;
            if (size == "Small")
            {
                totalprice = 8 + (float)(toppings * .20);
            }
            else if (size == "Medium")
            {
                totalprice = 10 + (float)(toppings * .50);
            }
            else if (size == "Large")
            {
                totalprice = 12 + (toppings);
            }
            return totalprice;
        }

    }



}
