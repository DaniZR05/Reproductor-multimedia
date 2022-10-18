using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Reproductor_multimedia
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = lbListaArchivos.SelectedItem as MediaFile;
            if (file != null)
            {
                mpMediaPlayer.URL = file.Path;
                mpMediaPlayer.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames =
                true, Filter = "WMV|*.wmv|WAV|*.wav|MP3|*.mp3|MP4|*.mp4|MKV|*.mkv"
            })
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> list = new List<MediaFile>();
                    foreach (string FileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(FileName);
                        file.add(new MediaFile() { FileName =
                            Path.GetFileNameWithoutExtension(fi.FullName),
                            Path = fi.FullName
                        });
                    }
                    lbListaArchivos.DataSource = file;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lbListaArchivos.ValueMember = "Path";
            lbListaArchivos.DisplayMember = "FileName";
        }
    }
}
