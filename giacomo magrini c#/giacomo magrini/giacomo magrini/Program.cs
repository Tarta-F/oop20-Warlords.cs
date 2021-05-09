using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace giacomo_magrini
{



    static class Program
    {
        public static SoundPlayer splayer = new SoundPlayer();
        public static bool musicOnOff;

      

        
        // <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            musicOnOff = true;
            splayer.SoundLocation = "Main_menu_music.wav";
            splayer.PlayLooping();
            Application.Run(new Form1());

        }


    }
}
