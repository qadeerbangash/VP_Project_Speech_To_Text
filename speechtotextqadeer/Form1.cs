using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;

namespace speechtotextqadeer
{
    public partial class Form1 : Form
    {
       SpeechRecognitionEngine speaker = new SpeechRecognitionEngine();
        public Form1()
        {
            InitializeComponent();
            
        }


       

        SpeechSynthesizer read = new SpeechSynthesizer();
        PromptBuilder buld = new PromptBuilder();
       // SpeechRecognitionEngine speaker = new SpeechRecognitionEngine();
        //Choices clist;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Aqua;
            read.SpeakAsync("Welcome...! to my first speak recognized Application ");
            label1.Text = Convert.ToString(trackBar1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
               
                read.SpeakAsync("Please Enter Some Text in TextBox");
            }
            else
            {
                if (comboBox1.Text == "Male")
                {
                   
                    read.SelectVoiceByHints(VoiceGender.Male);
                    read.Volume = trackBar1.Value;
                    read.Speak(richTextBox1.Text);
                }
                if (comboBox1.Text == "Female")
                {
                    read.SelectVoiceByHints(VoiceGender.Female);
                    read.Volume = trackBar1.Value;
                    read.Speak(richTextBox1.Text);
                }
               // MessageBox.Show(richTextBox1.Text.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*  button2.Enabled = false;
              button4.Enabled = true;
              clist.Add(new string[] { "hello", "how are you", "what is the current time", "thank you", "close" });
              Grammar gr = new Grammar(new GrammarBuilder(clist));

              try
              {
                  speaker.RequestRecognizerUpdate();
                  speaker.LoadGrammar(gr);
                  speaker.SpeechRecognized += Speaker_SpeechRecognized;
                  speaker.SetInputToDefaultAudioDevice();
                  speaker.RecognizeAsync(RecognizeMode.Multiple);
              }
              catch(Exception ex)
              {
                  MessageBox.Show(ex.Message, "error");
              }
          }

          private void Speaker_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
          {
              switch(e.Result.Text.ToString())
              {
                  case "hello":
                      read.SpeakAsync("hello qadeer");
                      break;
                  case "how are you":
                      read.SpeakAsync("I am doing great");
                      break;
                  case "what is the current time":
                      read.SpeakAsync("current time is " + DateTime.Now.ToString());
                      break;
                  case "thank you":
                      read.SpeakAsync("Pleasure is mine qadeer");
                      break;
                  case "close":
                      Application.Exit();
                      break;

              }
              */
            Grammar gr = new DictationGrammar();
            speaker.LoadGrammarAsync(gr);
            try
            {
                speaker.SetInputToDefaultAudioDevice();
                RecognitionResult rs = speaker.Recognize();
                richTextBox1.Text = rs.Text;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                speaker.UnloadAllGrammars();
            }
        }

        

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(trackBar1.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }
    }
}
