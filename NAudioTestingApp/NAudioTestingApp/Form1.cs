using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Midi;
using System.Threading;

namespace NAudioTestingApp
{
    

    public partial class Form1 : Form
    {
        Music mus;

        Thread oThread;
        Thread tThread;

        public Form1()
        {
            InitializeComponent();

            mus = new Music();
            oThread = new Thread(new ThreadStart(mus.Play));
            tThread = new Thread(new ThreadStart(mus.PlayNotes));

            oThread.Start();
            tThread.Start();

            while (!oThread.IsAlive) ;
            while (!tThread.IsAlive) ;

            

        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            oThread.Interrupt();
            tThread.Interrupt();

            oThread.Abort();
            tThread.Abort();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.P)
            {
                GlobVars.playSound = !GlobVars.playSound;
            }
        }

        private void btnPlay_MouseDown(object sender, MouseEventArgs e)
        {
            GlobVars.isPressed = true;
        }
    }

    public static class GlobVars
    {
        public static bool isPressed = false;
        public static bool playSound = true;

    }
}
