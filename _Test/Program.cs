﻿using System;

namespace _Test
{
    internal class Program
    {
        private static void Main (string[] args)
        {
            //Test7_Dome test7_ = new Test7_Dome();
            Test8_Dome test8_ = new Test8_Dome();

            //test7_.WriteFile();
            //test7_.ReadFile();
            test8_.WriteJsonFile();
            test8_.ReadJsonFile();

            Console.ReadKey();
        }
    }
}
