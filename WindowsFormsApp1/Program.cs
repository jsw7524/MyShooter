﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    



    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Timer GameTimer = new Timer();
            GameTimer.Interval = 1000/30;
            GameTimer.Start();

            Application.Run(new Form1(new GameMgr(GameTimer), GameTimer));
        }
    }
}
