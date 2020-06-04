using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace movingObjectsDownTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        token[] redTokens = new token[50];
        Bitmap redImage = new Bitmap(@"../../../redCircle.png");
        int redDist = 2;
        int down = 1;
        int up = -1;
        int right = 1;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void redDown_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < redTokens.Length; i++)
            {
                redTokens[i].moveUpDown(down, redDist);
                if (redTokens[i].TokenPictureBox.Location.Y >= this.Height + 50)
                {
                    redTokens[i].resetPosition();
                    int xCoordinate = rand.Next(this.Width - 50);
                    redTokens[i].moveRightLeft(right, xCoordinate);
                    //notIntersect();
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < redTokens.Length; i++)
            {
                int xCoordinate = rand.Next(this.Width - 100);
                int yCoordinate = rand.Next(-1000, 0);
                redTokens[i] = new token(xCoordinate, yCoordinate, redImage);
                Controls.Add(redTokens[i].TokenPictureBox);
                //notIntersect();
            }

                redDown.Enabled = true;
        }

        //public void notIntersect()
        //{
        //
        //    for (int i = 0; i < redTokens.Length; i++)
        //    {
        //        for (int z = i; z > 0; z--)
        //        {
        //            if (redTokens[i].TokenPictureBox.Bounds.IntersectsWith(redTokens[z-1].TokenPictureBox.Bounds))
        //            {
        //                redTokens[i].moveUpDown(up, 10);
        //                z = i + 1;
        //            }
        //        }
        //    }
        //}
    }
}
