using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops.Signatures;
using Vlc.DotNet.Forms.TypeEditors;

namespace Vlc.DotNet.Forms
{
    public partial class VlcControl : Control, ISupportInitialize
    {
        private VlcMediaPlayer myVlcMediaPlayer;

        [Editor(typeof(DirectoryEditor), typeof(UITypeEditor))]
        public DirectoryInfo VlcLibDirectory { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool IsPlaying
        {
            get { return myVlcMediaPlayer.IsPlaying(); }
        }

        public void BeginInit()
        {
        }

        public void EndInit()
        {
            if (IsInDesignMode() || myVlcMediaPlayer != null)
                return;
            if (VlcLibDirectory == null && (VlcLibDirectory = OnVlcLibDirectoryNeeded()) == null)
            {
                throw new Exception("'VlcLibDirectory' must be set.");
            }
            myVlcMediaPlayer = new VlcMediaPlayer(VlcLibDirectory);
            myVlcMediaPlayer.VideoHostControlHandle = Handle;
            RegisterEvents();
        }

        // work around http://stackoverflow.com/questions/34664/designmode-with-controls/708594
        private static bool IsInDesignMode()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }

        public event EventHandler<VlcLibDirectoryNeededEventArgs> VlcLibDirectoryNeeded;

        protected override void Dispose(bool disposing)
        {
            if (myVlcMediaPlayer != null)
            {
                UnregisterEvents();
                if (IsPlaying)
                    Stop();
                myVlcMediaPlayer.Dispose();
                base.Dispose(disposing);
                GC.SuppressFinalize(this);
            }
        }

        public DirectoryInfo OnVlcLibDirectoryNeeded()
        {
            var del = VlcLibDirectoryNeeded;
            if (del != null)
            {
                var args = new VlcLibDirectoryNeededEventArgs();
                del(this, args);
                return args.VlcLibDirectory;
            }
            return null;
        }

        public void Play()
        {
            EndInit();
            myVlcMediaPlayer.Play();
        }

        public void Play(FileInfo file, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
            Play();
        }

        public void Play(Uri uri, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(uri, options);
            Play();
        }

        public void Pause()
        {
            EndInit();
            myVlcMediaPlayer.Pause();
        }

        public void Stop()
        {
            EndInit();
            myVlcMediaPlayer.Stop();
        }

        public VlcMedia GetCurrentMedia()
        {
            EndInit();
            return myVlcMediaPlayer.GetMedia();
        }

        public float Position
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Position;
                else
                    return 0f;
            }
            set 
            {
                if(myVlcMediaPlayer != null)
                myVlcMediaPlayer.Position = value; 
            }
        }

        public IChapterManagement Chapter
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Chapters;
                else
                    return null;
            }
        }

        public float Rate
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Rate;
                else
                    return 0;
            }
            set
            {
                if (myVlcMediaPlayer != null)
                    myVlcMediaPlayer.Rate = value;
            }
        }

        public MediaStates State
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.State;
                else
                    return MediaStates.NothingSpecial;
            }
        }

        public ISubTitlesManagement SubTitles
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.SubTitles;
                else
                    return null;
            }
        }

        public IVideoManagement Video
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Video;
                else
                    return null;
            }
        }

        public IAudioManagement Audio
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Audio;
                else
                    return null;
            }
        }

        public long Length
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Length;
                else
                    return 0;

            }
        }

        public long Time
        {
            get
            {
                if (myVlcMediaPlayer != null)
                    return myVlcMediaPlayer.Time;
                else
                    return 0;
            }

            set
            {
                if (myVlcMediaPlayer != null)
                    myVlcMediaPlayer.Time = value;
            }
        }

        public void SetMedia(FileInfo file, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
        }

        public void SetMedia(Uri file, params string[] options)
        {
            EndInit();
            myVlcMediaPlayer.SetMedia(file, options);
        }
    }
}