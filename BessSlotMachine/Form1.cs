using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BessSlotMachine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int img1, img2, img3;
        double bet = 0;
        double totalIn = 0;
        double total = 0;
       
        Random numRand = new Random();

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(total > 0)
            {
                MessageBox.Show(string.Concat("You won ", total, " dollars! Total Bet: ", totalIn), "Winnings", MessageBoxButtons.OK);
            }
           else if(total == 0)
            {
                MessageBox.Show(string.Concat("You broke even. Total Bet: ", totalIn), "No Winnings", MessageBoxButtons.OK);
            }
           else
            {
                MessageBox.Show(string.Concat("You lost ", total * -1, " dollars. Total Bet: ", totalIn), "Better Luck Next Time", MessageBoxButtons.OK);
            }
            Close();
        }

        private void imageLoad(PictureBox pb, ref int num)
        {
            num = numRand.Next(0, 9);
            switch (num){
                case 0:
                    pb.Load("../FruitSymbols/Apple.bmp");
                    break;
                case 1:
                    pb.Load("../FruitSymbols/Banana.bmp");
                    break;
                case 2:
                    pb.Load("../FruitSymbols/Cherries.bmp");
                    break;
                case 3:
                    pb.Load("../FruitSymbols/Grapes.bmp");
                    break;
                case 4:
                    pb.Load("../FruitSymbols/Lemon.bmp");
                    break;
                case 5:
                    pb.Load("../FruitSymbols/Lime.bmp");
                    break;
                case 6:
                    pb.Load("../FruitSymbols/Orange.bmp");
                    break;
                case 7:
                    pb.Load("../FruitSymbols/Pear.bmp");
                    break;
                case 8:
                    pb.Load("../FruitSymbols/Strawberry.bmp");
                    break;
                case 9:
                    pb.Load("../FruitSymbols/Watermelon.bmp");
                    break;

            }

        }



        private void btnSpin_Click(object sender, EventArgs e)
        {
            if(double.TryParse(tbBet.Text, out bet))
            {
                if(bet > 0)
                {
                    total -= bet;
                    totalIn += bet;
                    imageLoad(pbSlot1, ref img1);
                    imageLoad(pbSlot2, ref img2);
                    imageLoad(pbSlot3, ref img3);
                    if(img1 == img2 && img2 == img3)
                    {
                        total += bet * 3;
                        MessageBox.Show(string.Concat("You won ", bet * 3, "$!"), "Winner", MessageBoxButtons.OK);
                    }
                    else if(img1 == img2 || img1 == img3 || img2 == img3)
                    {
                        total += bet * 2;
                        MessageBox.Show(string.Concat("You won ", bet * 2, "$!"), "Winner", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("You won 0$", "Try Again!", MessageBoxButtons.OK);
                    }
                }
                else if(bet == 0)
                {
                    MessageBox.Show("Invalid Bet: This machine needs to make money too. Please bet more than 0.00$. Thank You", "This isnt a free game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Invalid Bet: You can't flip the odds on us. Please enter an amount greater than 0.00$.", "The house should ALMOST always win", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid Bet: Please enter a valid number of dollars to bet", "Bad Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
