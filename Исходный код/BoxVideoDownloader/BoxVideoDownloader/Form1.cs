using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




//мои юзынги
using System.Diagnostics; //cmd для выполнения произвольной команды

using System.IO; // show dialog показать диалоговое окно сохранения



namespace BoxVideoDownloader
{
    public partial class Form1 : Form
    {
        //переменные которые содержат пустой путь 
        
        string output = System.IO.Path.Combine(Application.StartupPath, "");
        string output2 = System.IO.Path.Combine(Application.StartupPath, "");
        string path = System.IO.Path.Combine(Application.StartupPath, "");


        string pathDesktop = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Desktop");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
        }
        

        //путь сохранения картинка m3u8
        void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Видео (*. mp4) | * .mp4 | Рабочий лист (*. mp4) | * .mp4";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                output = sfd.FileName;
                label4.Text = output.ToString();

                //output = saveFileDialog1.FileName;
                //label4.Text = output.ToString();
            }

        }

        //кнопка скачивания m3u8
        private void button1_Click(object sender, EventArgs e)
        {

            string linkM3u8 = textBox1.Text.ToString();

            string PathM3u8 = output;

            ProcessStartInfo psi = new ProcessStartInfo();
            //Имя запускаемого приложения
            psi.FileName = "cmd";
            //команда, которую надо выполнить

            psi.Arguments = $" @\"/k ffmpeg -i {linkM3u8} -c copy -bsf:a aac_adtstoasc {PathM3u8} ";



            //  /c - после выполнения команды консоль закроется
            //  /к - не закрывать консоль после выполнения команды
            Process.Start(psi);

        }



        //путь сохранения видео  youtube
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    label5.Text = path.ToString();
                }

            }
        }

        //путь сохранения плэйлиста  youtube
        void pictureBox10_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    label13.Text = path.ToString();
                }

            }

        }





        //кнопка скачивания youtube

        //обычный ролик
        private void button2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            string linkYoutube = textBox2.Text.ToString();



            //если true то скачать только аудио
            if (checkBox1.Checked == true)
            {
                //Имя запускаемого приложения
                psi.FileName = "cmd";
                //команда, которую надо выполнить


                psi.Arguments = $" @\"/k cd {path} && yt-dlp  --extract-audio --audio-format mp3 {linkYoutube}  -o %(title)s.%(ext)s ";

                //  /c - после выполнения команды консоль закроется
                //  /к - не закрывать консоль после выполнения команды
                Process.Start(psi);
            }
            else //false скачать как видео
            {
                //Имя запускаемого приложения
                psi.FileName = "cmd";
                //команда, которую надо выполнить

                //строка --merge-output-format mp4 озночает что видео даже если webm то оно конвертнется в mp4
                psi.Arguments = $" @\"/k cd {path} && yt-dlp  {linkYoutube}  --merge-output-format mp4";


                //  /c - после выполнения команды консоль закроется
                //  /к - не закрывать консоль после выполнения команды
                Process.Start(psi);
            }
        }


        // плэйлист

        private void button4_Click(object sender, EventArgs e)
        {
            //если галка нажата то скачает в формате mp3
            if (checkBox2.Checked == true)
            {
                ProcessStartInfo playlist = new ProcessStartInfo();

                string linkYoutubePlaylist = textBox3.Text.ToString();


                //Имя запускаемого приложения
                playlist.FileName = "cmd";
                //команда, которую надо выполнить
                //здесь выпоняются несоклько команд сначало переход в директорию , а затем скачивание плейлиста .Чтобы выпонить несоклько команд поочередно я юзаю &&
                playlist.Arguments = $" @\"/k cd {path} && yt-dlp  --extract-audio --audio-format mp3  {linkYoutubePlaylist}  -o %(title)s.%(ext)s";


                //  /c - после выполнения команды консоль закроется
                //  /к - не закрывать консоль после выполнения команды
                Process.Start(playlist);
            }
            else //если не нажата то скачает в формате mp4
            {
                ProcessStartInfo playlist = new ProcessStartInfo();

                string linkYoutubePlaylist = textBox3.Text.ToString();


                //Имя запускаемого приложения
                playlist.FileName = "cmd";
                //команда, которую надо выполнить
                //здесь выпоняются несоклько команд сначало переход в директорию , а затем скачивание плейлиста .Чтобы выпонить несоклько команд поочередно я юзаю &&
                playlist.Arguments = $" @\"/k cd {path} && yt-dlp --no-playlist  {linkYoutubePlaylist} --merge-output-format mp4";


                //  /c - после выполнения команды консоль закроется
                //  /к - не закрывать консоль после выполнения команды
                Process.Start(playlist);
            }
        }


        //извлечь аудио
        //находим файл
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            OpenFileDialog PathAudioOpen = new OpenFileDialog();
            PathAudioOpen.Filter = "Видео | * .mp4";
            if (PathAudioOpen.ShowDialog() == DialogResult.OK)
            {
                output = PathAudioOpen.FileName;
                label10.Text = output.ToString();
            }
        }
        //сохраняем файл
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SaveFileDialog PathAudioSave = new SaveFileDialog();
            PathAudioSave.Filter = "Аудио | * .mp3";
            if (PathAudioSave.ShowDialog() == DialogResult.OK)
            {
                output2 = PathAudioSave.FileName;
                label8.Text = output2.ToString();
            }
        }

        //кнопка извлечь аудио
        private void button3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();

            string AudioOpen = output;
            string AudioSave = output2;
            //Имя запускаемого приложения
            psi.FileName = "cmd";
            //команда, которую надо выполнить

            psi.Arguments = $" @\"/k ffmpeg -i {AudioOpen} -vn -ar 44100 -ac 2 -ab 192K -f mp3 {AudioSave}";


            //  /c - после выполнения команды консоль закроется
            //  /к - не закрывать консоль после выполнения команды
            Process.Start(psi);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }




}

}
