using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using final;
using System.IO;



namespace final
{
    public partial class Form1 : Form
    {
        int length = 0;
        OpenFileDialog wav_file = new OpenFileDialog();
        bool file_existence = false;
        int timer = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        public void playsound()
        {
            if (file_existence)
            {
                SoundPlayer simpleSound = new SoundPlayer(wav_file.FileName); // create a variable for a sound which take the path of the sound
                simpleSound.Play();
                // play the sound
               
            }
            else
            {
                MessageBox.Show("sorry, you should choose a file.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playsound();
            timer1.Enabled = true;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wav_file.Filter = "Wave file (*.wav)|*.wav;"; // specific the selected file only to a wave file extention 
            if (wav_file.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            { // to open a dialog to chosen 
                //string chosen_file = wav_file.FileName ;
                //MessageBox.Show(chosen_file);
                button1.Enabled = true;
                file_existence = true;


                FileStream x = new FileStream(wav_file.FileName, FileMode.Open, FileAccess.Read);  // object have the file and open it reads it's information
                
                int leng = (int)x.Length;
                

                int result = 0;
                result = ((leng / 1024) * 8) / 1411; // equation about wav file convert length to duration using the bit rate of wav (1141) and length in kbyte
                length = result;
               
               TimeSpan s =  TimeSpan.FromMilliseconds(result*1000);
                lbl_totallength.Text = s.Hours + ":" + s.Minutes + ":" + s.Seconds;
                label1.Text =result.ToString()+" "+"sec";
               trackBar1.Maximum = 100;
               
               


            }
        }

 private void button3_Click(object sender, EventArgs e)
 {

    
    }

 private void trackBar1_Scroll(object sender, EventArgs e)
 {
     

 }

 private void timer1_Tick(object sender, EventArgs e)
 {
     TimeSpan ts = TimeSpan.FromMilliseconds(timer);
     Current_Time.Text = ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds;
     
     
     if (timer < length * 1000)
     {
         timer += 10;
         int value = trackBar1.Maximum * timer / (length * 1000);
         trackBar1.Value = value;
     }
     else
     {
         trackBar1.Value = 0;
         timer1.Stop();
         ts = TimeSpan.FromMilliseconds(0);
         timer = 0;

     }
      
     

 }

 private void label1_Click(object sender, EventArgs e)
 {

 }

 private void Form1_Load(object sender, EventArgs e)
 {

 }

 private void starttime_Tick(object sender, EventArgs e)
 {
     
 }

        }
    }

