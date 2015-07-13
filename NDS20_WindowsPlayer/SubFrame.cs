using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using System.Net.Json;

namespace NDS20_WindowsPlayer
{
    public class SubFrame : Vlc.DotNet.Forms.VlcControl
    {
        public SubFrame(JsonObject jsonSchedule) :base()
        {
            JsonObjectCollection col = (JsonObjectCollection)jsonSchedule;
            //string jsonstr = col.ToString();
            

            int xPos = int.Parse(col["xPos"].GetValue().ToString());
            int yPos = int.Parse(col["yPos"].GetValue().ToString());
            int hLen = int.Parse(col["hLen"].GetValue().ToString());
            int vLen = int.Parse(col["vLen"].GetValue().ToString());
            string media = (string)col["fileName"].GetValue();
            int volum = int.Parse(col["volume"].GetValue().ToString());

            BackColor = System.Drawing.Color.Black;
            Location = new System.Drawing.Point(xPos,yPos);
            Name = "NDS20 Player";
            Size = new System.Drawing.Size(hLen, vLen);
            TabIndex = 0;
            Text = "NDSPlayerControl";

            VlcLibDirectory = null;
            VlcLibDirectoryNeeded += new
                System.EventHandler<Vlc.DotNet.Forms.VlcLibDirectoryNeededEventArgs>
                (this.OnVlcControlNeedLibDirectory);
            
            SetMedia(new FileInfo(@media));

            // Audio.Volume = 10;
            Rate = 2.0f;
           }

        public void SetVolume(int vol)
        {
            Audio.Volume = vol;
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            if (currentDirectory == null)
                return;
            if (AssemblyName.GetAssemblyName(currentAssembly.Location).ProcessorArchitecture == ProcessorArchitecture.X86)
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\lib\x86\"));
            else
                e.VlcLibDirectory = new DirectoryInfo(Path.Combine(currentDirectory, @"..\..\..\lib\x64\"));

            if (!e.VlcLibDirectory.Exists)
            {
                var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
                folderBrowserDialog.Description = "Select Vlc libraries folder.";
                folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    e.VlcLibDirectory = new DirectoryInfo(folderBrowserDialog.SelectedPath);
                }
            }
        }
 //       public Vlc.DotNet.Forms.VlcControl videoPlayer;

        public string getMessage(string subfixString)
        {
            return "New subform!!" + subfixString;
        }

    }
}
