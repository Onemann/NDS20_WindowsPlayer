using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Json;

namespace NDS20_WindowsPlayer
{
    public partial class NDS20frmMain : Form
    {
        private int idxSubFrame;
        public List <SubFrame> movieFrames; // for dynamic creation
        public List<string> strInSchdl;

        public NDS20frmMain()
        {
            InitializeComponent();

            // Creates or loads an INI file in the same directory as your executable
            var MyIni = new IniFile();
            MyIni.Write("DefaultVolume", "100");
            MyIni.Write("HomePage", "http://www.google.com");

            // Creates video player dynamic object array. 
            movieFrames = new List<SubFrame>();
            strInSchdl = new List<string>();
        }

        
        private void NDS20frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape :
                    this.Controls.Clear();
                    //this.Close();
                    Application.Exit();
                    break;

                case Keys.F7 :

                    break;
            }
  
        }

        private void button1_Click(object sender, EventArgs e)
        {

            picbMainLogo.Visible = false;
            
#region 테스트 코딩
            strInSchdl.Add(
                "{" +
                " \"xPos\": 100," +
                " \"yPos\": 0," +
                " \"hLen\": 360," +
                " \"vLen\": 200," +
                " \"fileName\": \"d:/Projects/NDS/Contents/A.avi\"," +
                " \"volume\": 0 " +
                "}"
                );

            strInSchdl.Add(
                "{" +
                " \"xPos\": 400," +
                " \"yPos\": 100," +
                " \"hLen\": 500," +
                " \"vLen\": 280," +
                " \"fileName\": \"d:/Projects/NDS/Contents/A.tp\"," +
                " \"volume\": 0 " +
                "}"
                );

            strInSchdl.Add(
                "{" +
                " \"xPos\": 200," +
                " \"yPos\": 300," +
                " \"hLen\": 500," +
                " \"vLen\": 350," +
                " \"fileName\": \"d:/Projects/NDS/Contents/A.wmv\"," +
                " \"volume\": 100 " +
                "}"
                );
            JsonTextParser parser = new JsonTextParser();
            JsonObject jsonShdlObj = parser.Parse(strInSchdl[0]);
#endregion

            movieFrames.Add(new SubFrame(jsonShdlObj));
            idxSubFrame = movieFrames.Count - 1;

            this.Controls.Add(movieFrames[idxSubFrame]);

            jsonShdlObj = parser.Parse(strInSchdl[1]);
            movieFrames.Add(new SubFrame(jsonShdlObj));
            idxSubFrame = movieFrames.Count - 1;

            this.Controls.Add(movieFrames[idxSubFrame]);

            jsonShdlObj = parser.Parse(strInSchdl[2]);
            movieFrames.Add(new SubFrame(jsonShdlObj));
            idxSubFrame = movieFrames.Count - 1;

            this.Controls.Add(movieFrames[idxSubFrame]);


//            movieFrames[idxSubFrame].Play();

            movieFrames[0].Play();
            movieFrames[1].Play();
            movieFrames[2].Play();
            
            
            //MessageBox.Show(subFrame.getMessage(" OK"));
            //movieFrames[0].Audio.Volume = 0;
            //movieFrames[1].Audio.Volume = 0;
            //movieFrames[2].Audio.Volume = 0;

            movieFrames[1].SetVolume(0);
            movieFrames[2].SetVolume(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //movieFrames[0].Play();
            //movieFrames[1].Play();
            //movieFrames[2].Play();
            movieFrames[0].Stop();
            movieFrames[1].Stop();
            movieFrames[2].Stop();


            //movieFrames.Clear();
            strInSchdl.Clear();
        }

        private void NDS20frmMain_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            movieFrames[0].Audio.Volume = 0;
            movieFrames[1].Audio.Volume = 0;
            movieFrames[2].Audio.Volume = 0;
        }
    }
}
