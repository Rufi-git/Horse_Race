using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horse_Race
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random random = new Random();
        bool endGame = false;

        private void button1_Click(object sender, EventArgs e)
        {
            gamer_timer.Enabled = true;
            start_button.Visible = false;
            start_again_button.Left = 12;
            stop_button.Left = 200;
            continue_btn.Left = 369;
        }
        

        private void gamer_timer_Tick(object sender, EventArgs e)
        {
            
            int firstHorse = pc_bx_first.Left + pc_bx_first.Width + 30;
            int secondHorse = pc_bx_second.Left + pc_bx_second.Width + 30;
            int thirdHorse = pc_bx_white.Left + pc_bx_white.Width + 30;

            pc_bx_first.Left = pc_bx_first.Left + random.Next(5, 25);
            pc_bx_second.Left = pc_bx_second.Left + random.Next(5, 25);
            pc_bx_white.Left = pc_bx_white.Left + random.Next(5, 25);

            int finish = lbl_finish_line.Left;

            int whiteHorseScore = Convert.ToInt32(white_horse_score.Text);
            int yellowHorseScore = Convert.ToInt32(yellow_horse_score.Text);
            int redHorseScore = Convert.ToInt32(red_horse_score.Text);

            if (firstHorse >= finish)
            {
                redHorseScore += 20;

                red_horse_score.Text = Convert.ToString(redHorseScore);

                gamer_timer.Enabled = false;
                endGame = true;
                MessageBox.Show("Qırmızı at qalib geldi!");
                pc_bx_first.Left = 0;
                pc_bx_second.Left = 0;
                pc_bx_white.Left = 0;

            }

            if (secondHorse >= finish)
            {
                yellowHorseScore += 20;

                yellow_horse_score.Text = Convert.ToString(yellowHorseScore);

                gamer_timer.Enabled = false;
                endGame = true;
                MessageBox.Show("Sarı at qalib geldi!");
                pc_bx_first.Left = 0;
                pc_bx_second.Left = 0;
                pc_bx_white.Left = 0;

            }

            if (thirdHorse >= finish)
            {
                whiteHorseScore += 20;

                white_horse_score.Text = Convert.ToString(whiteHorseScore);

                gamer_timer.Enabled = false;
                endGame = true;
                MessageBox.Show("Ağ at qalib geldi!");
                firstHorse = 0;
                secondHorse = 0;
                thirdHorse = 0;
            }

            if (firstHorse > secondHorse&& firstHorse>thirdHorse)
            {
                horse_race_info.Text = "Qırmızı at onde gedir";
                first_place.Text = "Qırmızı at";
                level_red_horse.Top = 48;
            }

            if (secondHorse > firstHorse && secondHorse > thirdHorse)
            {
                horse_race_info.Text = "Sarı at onde gedir ve deyesen udacaq";
                first_place.Text = "Sarı at";
                level_yellow_horse.Top = 48;

            }

            if (thirdHorse > secondHorse && thirdHorse > firstHorse)
            {
                horse_race_info.Text = "Ağ at onde gedir!";
                first_place.Text = "Ağ at";
                level_white_horse.Top = 48;

            }

            if ((secondHorse < firstHorse && secondHorse > thirdHorse) || (secondHorse > firstHorse && secondHorse < thirdHorse))
            {
                horse_race_info.Text += " ve Sarı at ikinci yerdedir";
                second_place.Text = "Sarı at";
                level_yellow_horse.Top = 215;

            }
            if ((firstHorse < secondHorse && firstHorse > thirdHorse) || (firstHorse > secondHorse && firstHorse < thirdHorse))
            {
                horse_race_info.Text += " ve Qırmızı at ikinci yerdedir!";
                second_place.Text = "Qırmızı at";
                level_red_horse.Top = 215;

            }
            if ((thirdHorse < secondHorse && thirdHorse > firstHorse) || (thirdHorse > secondHorse && thirdHorse < firstHorse))
            {
                horse_race_info.Text += " ve Ağ at ikinci yerdedir";
                second_place.Text = "Ağ at";
                level_white_horse.Top = 215;

            }


            if (firstHorse<secondHorse && firstHorse < thirdHorse)
            {
                third_place.Text = "Qırmızı at";
                level_red_horse.Top = 415;

            }

            if (secondHorse < firstHorse && secondHorse < thirdHorse)
            {
                third_place.Text = "Sarı at";
                level_yellow_horse.Top = 415;

            }

            if (thirdHorse < secondHorse && thirdHorse < firstHorse)
            {
                third_place.Text = "Ağ at";
                level_white_horse.Top = 415;

            }
        }
        bool start_again = false;
        private void button1_Click_1(object sender, EventArgs e)
        {
            pc_bx_first.Left = 0;
            pc_bx_second.Left = 0;
            pc_bx_white.Left = 0;
            start_again = true;

            gamer_timer.Enabled = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if ((endGame==true)) { 
                if (start_again == true)
                {
                    gamer_timer.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Mee catmire sen qurtarmis oyunu nece dayandira bilersen!");
                }
            }
            else
            {
                gamer_timer.Enabled = false;
            }
        }

        private void continue_btn_Click(object sender, EventArgs e)
        {
            if (endGame == true)
            {
                if (start_again == true)
                {
                    gamer_timer.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Oyun artiq bitibee");
                }
            }
            else
            {
                gamer_timer.Enabled = true;
            }
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            int redHorseScore = Convert.ToInt32(red_horse_score.Text);

            
            if (redHorseScore > 0)
            {
                redHorseScore -= 5;
                red_horse_score.Text = Convert.ToString(redHorseScore);
            }
            else
            {
                MessageBox.Show("Yeteri qeder scorunuz yoxdur");
                return;
            }

            

            

            if (!(pc_bx_first.Left + pc_bx_first.Width + 30 >= lbl_finish_line.Left))
            {
                
                if (!(endGame == true))
                {
                    pc_bx_first.Left += 20;
                }
                else
                {
                    if (start_again==true)
                    {
                        pc_bx_first.Left += 20;
                    }
                    else
                    {
                        MessageBox.Show("Sen onsuz uduzmusan eee evvelden basardinda bu duymeni");
                    }
                }
            }
            else
            {
                MessageBox.Show("Qırmızı at onsuzda qazanifsan ne isteyirsen axi");
                gamer_timer.Enabled = false;
                endGame = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int yellowHorseScore = Convert.ToInt32(yellow_horse_score.Text);

            if (yellowHorseScore > 0)
            {
                yellowHorseScore -= 5;
                yellow_horse_score.Text = Convert.ToString(yellowHorseScore);
            }
            else
            {
                MessageBox.Show("Yeteri qeder scorunuz yoxdur");
                return;
            }
            if (!(pc_bx_second.Left + pc_bx_second.Width + 30 >= lbl_finish_line.Left))
            {

                if (!(endGame == true))
                {
                    pc_bx_second.Left += 20;
                }
                else
                {
                    if (start_again == true)
                    {
                        pc_bx_second.Left += 20;
                    }
                    else
                    {
                        MessageBox.Show("Sen onsuz uduzmusan eee evvelden basardinda bu duymeni");
                    }
                }
            }
            else
            {
                MessageBox.Show("Sarı at onsuzda qazanifsan ne isteyirsen axi Get sukur elə");
                gamer_timer.Enabled = false;
                endGame = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int whiteHorseScore = Convert.ToInt32(white_horse_score.Text);

            if (whiteHorseScore > 0)
            {
                whiteHorseScore -= 5;
                white_horse_score.Text = Convert.ToString(whiteHorseScore);
            }
            else
            {
                MessageBox.Show("Yeteri qeder scorunuz yoxdur");
                return;
            }

            if (!(pc_bx_white.Left + pc_bx_white.Width + 30 >= lbl_finish_line.Left))
            {
                if (!(endGame == true))
                {
                    pc_bx_white.Left += 20;
                }
                else
                {
                    if (start_again == true)
                    {
                        pc_bx_white.Left += 20;
                    }
                    else
                    {
                        MessageBox.Show("Sen onsuz uduzmusan eee evvelden basardinda bu duymeni");
                    }
                }
            }
            else
            {
                MessageBox.Show("Ağ at onsuzda qazanifsan ne isteyirsen axi");
                gamer_timer.Enabled = false;
                endGame = true;
            }
        }
    }
}
