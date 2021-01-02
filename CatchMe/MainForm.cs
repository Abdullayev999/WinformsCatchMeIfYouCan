using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchMe
{
    public partial class MainForm : Form
    {
        static int Count { get; set; } = 0;
        public MainForm()
        {
            InitializeComponent();
        }

        private void CatchMebutton_MouseMove(object sender, MouseEventArgs e)
        {
            if (progressBar1.Value<100)
            {
                Count++;
                ZeroLabel.Text = (Count*10).ToString();
                progressBar1.Value = Count * 10;
                Random rand=new Random();

                if (CatchMebutton.Location!=MousePosition)
                {
                    CatchMebutton.Location = new Point(x: rand.Next(0,380), y: rand.Next(65, 340));
                }

            

                if (!(CatchMebutton.Location.X < 380&& CatchMebutton.Location.X >= 0 && CatchMebutton.Location.Y < 340 && CatchMebutton.Location.Y >= 65))
                {
                    CatchMebutton.Location = new Point(x: 150, y: 150);
                }
            }
            else
            {
                var result=MessageBox.Show("You exit?", "The game is overe", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Close();
                }
                else if(result == DialogResult.No)
                {
                    var result2 = MessageBox.Show("New game?", "Catch me", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result2 == DialogResult.Yes)
                    {
                        Count = 0;
                        ZeroLabel.Text = 0.ToString();
                        progressBar1.Value = 0;
                    }
                }
            }

            
        }

        private void Form1_MouseMove_1(object sender, MouseEventArgs e)
        {
            Text = $"Y = {e.Y} X = {e.X}";
        }
    }
}
