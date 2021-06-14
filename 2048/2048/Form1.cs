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

namespace _2048
{
    
    public partial class Form1 : Form
    {
        int[,] a = new int[4, 4];
        Random random1 = new Random();
        int x, y; //隨機產生的座標
        Boolean judge = false,movejudge=false;
        int score, best;
       
        
        public Form1()
        {
         
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          PictureBox[] piclist = { pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19 };
            while (judge == false)
            {
                x = random1.Next() % 4; y = random1.Next() % 4;
                if (a[x, y] == 0)
                {
                    a[x, y] = 2;
                    judge = true;
                }
                judge = false;
                x = random1.Next() % 4; y = random1.Next() % 4;
                if (a[x, y] == 0)
                {
                    a[x, y] = 2;
                    judge = true;
                }
            }

            int count=0;  //顯示方塊

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i, j] == 0)
                    {
                        piclist[count].Image = new Bitmap("0.png");
                        count++;
                    }
                    if (a[i, j] == 2)
                    {
                        piclist[count].Image = new Bitmap("2.png");
                        count++;
                    }
                }
            }

            best = Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt"));
            score = 0;

            label3.Text = Convert.ToString(score);
            label6.Text = Convert.ToString(best);

        }


        private void label4_Click(object sender, EventArgs e)
        {
            PictureBox[] piclist = { pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19 };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    a[i, j] = 0;


            x = 0; y = 0;
            judge = false;


            while (judge == false)
            {
                x = random1.Next() % 4; y = random1.Next() % 4;
                if (a[x, y] == 0)
                {
                    a[x, y] = 2;
                    judge = true;
                }
                judge = false;
                x = random1.Next() % 4; y = random1.Next() % 4;
                if (a[x, y] == 0)
                {
                    a[x, y] = 2;
                    judge = true;
                }
            }
            int count = 0;  //顯示方塊

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i, j] == 0)
                    {
                        piclist[count].Image = new Bitmap("0.png");
                        count++;
                    }
                    if (a[i, j] == 2)
                    {
                        piclist[count].Image = new Bitmap("2.png");
                        count++;
                    }              
                }
              
            }
            if(score > Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt")) ) 
            System.IO.File.WriteAllText(@"best.txt", Convert.ToString(score));



            best = Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt"));
            score = 0;

            label3.Text = Convert.ToString(score);
            label6.Text = Convert.ToString(best);

        }



        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("使用方向鍵讓方塊整體上下左右移動。\n如果兩個帶有相同數字的方塊在移動中碰撞，\n則它們會合併為一個方塊，且所帶數字變為兩者之和。\n每次移動時，會有一個值為2或者4的新方塊出現。\n當值為2048的方塊出現時，遊戲即勝利，\n反之即失敗。", "2048");
        }

     
    

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            PictureBox[] piclist = { pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19 };
          
            if (e.KeyCode == Keys.Left)
            { 
                int x = 0, y = 0 ;
                movejudge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j - 1 >= 0 && a[i, j] > 0)
                        {
                            x = i; y = j;
                            while (y - 1 >= 0 && a[x, y - 1] == 0 && a[x, y] > 0)
                            {
                                a[x, y - 1] = a[x, y]; a[x, y] = 0;
                                y--;
                                movejudge = true;
                            }
                        }
                    }
                    for (int j = 3; j >= 0; j--)
                    {
                        if( j-1>=0 && a[i,j]==a[i,j-1])
                        {
                            a[i, j-1] = a[i, j-1] * 2;a[i, j] = 0;
                            score = score + a[i, j-1];
                        }
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        if (j - 1 >= 0 && a[i, j] > 0)
                        {
                            x = i; y = j;
                            while (y - 1 >= 0 && a[x, y - 1] == 0 && a[x, y] > 0)
                            {
                                a[x, y - 1] = a[x, y]; a[x, y] = 0;
                                y--;
                                movejudge = true;
                            }
                        }
                    }
                }
            
                judge = false;
                for(int i=0;i<4;i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            judge = true;
                            break;
                        }
                    }
                }
                if(judge==true && movejudge == true)
                {
                    judge = false;
                    while (judge == false)
                    {
                        x = random1.Next() % 4; y = random1.Next() % 4;
                        if (a[x, y] == 0)
                        {
                            a[x, y] = 2;
                            judge = true;
                        }

                    }
                }
               


                int count = 0;  //顯示方塊
            
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            piclist[count].Image = new Bitmap("0.png");
                            count++;
                        }
                        if (a[i, j] == 2)
                        {
                            piclist[count].Image = new Bitmap("2.png");
                            count++;
                        }
                        if (a[i, j] == 4)
                        {
                            piclist[count].Image = new Bitmap("4.png");
                            count++;
                        }
                        if (a[i, j] == 8)
                        {
                            piclist[count].Image = new Bitmap("8.png");
                            count++;
                        }
                        if (a[i, j] == 16)
                        {
                            piclist[count].Image = new Bitmap("16.png");
                            count++;
                        }
                        if (a[i, j] == 32)
                        {
                            piclist[count].Image = new Bitmap("32.png");
                            count++;
                        }
                        if (a[i, j] == 64)
                        {
                            piclist[count].Image = new Bitmap("64.png");
                            count++;
                        }
                        if (a[i, j] == 128)
                        {
                            piclist[count].Image = new Bitmap("128.png");
                            count++;
                        }
                        if (a[i, j] == 256)
                        {
                            piclist[count].Image = new Bitmap("256.png");
                            count++;
                        }
                        if (a[i, j] == 512)
                        {
                            piclist[count].Image = new Bitmap("512.png");
                            count++;
                        }
                        if (a[i, j] == 1024)
                        {
                            piclist[count].Image = new Bitmap("1024.png");
                            count++;
                        }
                        if (a[i, j] == 2048)
                        {
                            piclist[count].Image = new Bitmap("2048.png");
                            count++;
                        }
                    }
                }
                label3.Text = Convert.ToString(score);

                Boolean judge2 = false;
                for(int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                       else if (i == 0 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                     else   if (i == 3 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左下角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                      else  if (i == 3 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i - 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i==0 && j>0 && j<3  )
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1])|| (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左右下
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 0 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i+1, j ]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //上下右
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 3 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左右上
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 3 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i+1, j ]) || (a[i, j] == a[i - 1, j])) //上下左
                            {
                                judge2 = true;
                                break;
                            }
                        }
                        else
                            
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //左右下
                            {
                                judge2 = true;
                                break;
                            }
                        

                    }
                }
    

                if (judge2 == false)
                {
                    if (score > Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt")))
                        System.IO.File.WriteAllText(@"best.txt", Convert.ToString(score));
                    if (MessageBox.Show("GAME OVER", "2048")== DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                int x = 0, y = 0;

                movejudge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j <4; j++)
                    {
                        if (j + 1 <= 3 && a[i, j] > 0)
                        {
                            x = i; y = j;
                            while (y + 1 <=3 && a[x, y + 1] == 0 && a[x, y] > 0)
                            {
                                a[x, y + 1] = a[x, y]; a[x, y] = 0;
                                y++;
                                movejudge = true;
                            }
                        }
                    }
                    for (int j = 3; j >= 0; j--)
                    {
                        if (j + 1 <=3 && a[i, j] == a[i, j + 1])
                        {
                            a[i, j+1] = a[i, j+1] * 2; a[i, j] = 0;
                            score = score + a[i, j+1];
                        }
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        if (j + 1 <= 3 && a[i, j] > 0)
                        {
                            x = i; y = j;
                            while (y + 1 <= 3 && a[x, y + 1] == 0 && a[x, y] > 0)
                            {
                                a[x, y + 1] = a[x, y]; a[x, y] = 0;
                                y++;
                                movejudge = true;
                            }
                        }
                    }
                }


                judge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            judge = true;
                            break;
                        }
                    }
                }
                if (judge == true && movejudge == true)
                {
                    judge = false;
                    while (judge == false)
                    {
                        x = random1.Next() % 4; y = random1.Next() % 4;
                        if (a[x, y] == 0)
                        {
                            a[x, y] = 2;
                            judge = true;
                        }

                    }
                }



                int count = 0;  //顯示方塊

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            piclist[count].Image = new Bitmap("0.png");
                            count++;
                        }
                        if (a[i, j] == 2)
                        {
                            piclist[count].Image = new Bitmap("2.png");
                            count++;
                        }
                        if (a[i, j] == 4)
                        {
                            piclist[count].Image = new Bitmap("4.png");
                            count++;
                        }
                        if (a[i, j] == 8)
                        {
                            piclist[count].Image = new Bitmap("8.png");
                            count++;
                        }
                        if (a[i, j] == 16)
                        {
                            piclist[count].Image = new Bitmap("16.png");
                            count++;
                        }
                        if (a[i, j] == 32)
                        {
                            piclist[count].Image = new Bitmap("32.png");
                            count++;
                        }
                        if (a[i, j] == 64)
                        {
                            piclist[count].Image = new Bitmap("64.png");
                            count++;
                        }
                        if (a[i, j] == 128)
                        {
                            piclist[count].Image = new Bitmap("128.png");
                            count++;
                        }
                        if (a[i, j] == 256)
                        {
                            piclist[count].Image = new Bitmap("256.png");
                            count++;
                        }
                        if (a[i, j] == 512)
                        {
                            piclist[count].Image = new Bitmap("512.png");
                            count++;
                        }
                        if (a[i, j] == 1024)
                        {
                            piclist[count].Image = new Bitmap("1024.png");
                            count++;
                        }
                        if (a[i, j] == 2048)
                        {
                            piclist[count].Image = new Bitmap("2048.png");
                            count++;
                        }
                    }
                }
                label3.Text = Convert.ToString(score);

                Boolean judge2 = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 0 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 3 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左下角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 3 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i - 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 0 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左右下
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 0 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //上下右
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 3 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左右上
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 3 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //上下左
                            {
                                judge2 = true;
                                break;
                            }
                        }
                        else

                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //左右下
                        {
                            judge2 = true;
                            break;
                        }


                    }
                }


                if (judge2 == false)
                {
                    if (score > Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt")))
                        System.IO.File.WriteAllText(@"best.txt", Convert.ToString(score));
                    if (MessageBox.Show("GAME OVER", "2048") == DialogResult.OK)
                    {
                        Close();
                    }
                }
            }

            if (e.KeyCode == Keys.Up)
            {
                int x = 0, y = 0;

                movejudge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if(j-1>=0 && a[j, i] > 0)
                        {
                            x = j;y = i;
                            while (x-1 >=0 && a[x-1, y] == 0 && a[x, y] > 0)
                            {
                                a[x-1, y ] = a[x, y]; a[x, y] = 0;
                                x--;
                                movejudge = true;
                            }
                        }     
                    }
                    for (int j = 0; j <4; j++)
                    {
                        if (j + 1 <= 3 && a[j,i] == a[j+1, i])
                        {
                            a[j,i] = a[j,i] * 2; a[j+1,i] = 0;
                            score = score + a[j, i];
                        }
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if (j - 1 >= 0 && a[j, i] > 0)
                        {
                            x = j; y = i;
                            while (x - 1 >= 0 && a[x - 1, y] == 0 && a[x, y] > 0)
                            {
                                a[x - 1, y] = a[x, y]; a[x, y] = 0;
                                x--;
                                movejudge = true;
                            }
                        }
                    }
                }

                judge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            judge = true;
                            break;
                        }
                    }
                }
                if (judge == true && movejudge == true )
                {
                    judge = false;
                    while (judge == false)
                    {
                        x = random1.Next() % 4; y = random1.Next() % 4;
                        if (a[x, y] == 0)
                        {
                            a[x, y] = 2;
                            judge = true;
                        }

                    }
                }




                int count = 0;  //顯示方塊

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            piclist[count].Image = new Bitmap("0.png");
                            count++;
                        }
                        if (a[i, j] == 2)
                        {
                            piclist[count].Image = new Bitmap("2.png");
                            count++;
                        }
                        if (a[i, j] == 4)
                        {
                            piclist[count].Image = new Bitmap("4.png");
                            count++;
                        }
                        if (a[i, j] == 8)
                        {
                            piclist[count].Image = new Bitmap("8.png");
                            count++;
                        }
                        if (a[i, j] == 16)
                        {
                            piclist[count].Image = new Bitmap("16.png");
                            count++;
                        }
                        if (a[i, j] == 32)
                        {
                            piclist[count].Image = new Bitmap("32.png");
                            count++;
                        }
                        if (a[i, j] == 64)
                        {
                            piclist[count].Image = new Bitmap("64.png");
                            count++;
                        }
                        if (a[i, j] == 128)
                        {
                            piclist[count].Image = new Bitmap("128.png");
                            count++;
                        }
                        if (a[i, j] == 256)
                        {
                            piclist[count].Image = new Bitmap("256.png");
                            count++;
                        }
                        if (a[i, j] == 512)
                        {
                            piclist[count].Image = new Bitmap("512.png");
                            count++;
                        }
                        if (a[i, j] == 1024)
                        {
                            piclist[count].Image = new Bitmap("1024.png");
                            count++;
                        }
                        if (a[i, j] == 2048)
                        {
                            piclist[count].Image = new Bitmap("2048.png");
                            count++;
                        }
                    }
                }
                label3.Text = Convert.ToString(score);

                Boolean judge2 = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 0 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 3 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左下角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 3 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i - 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 0 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左右下
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 0 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //上下右
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 3 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左右上
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 3 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //上下左
                            {
                                judge2 = true;
                                break;
                            }
                        }
                        else

                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //左右下
                        {
                            judge2 = true;
                            break;
                        }


                    }
                }

                if (judge2 == false)
                {
                    if (score > Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt")))
                        System.IO.File.WriteAllText(@"best.txt", Convert.ToString(score));
                    if (MessageBox.Show("GAME OVER", "2048") == DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
            if (e.KeyCode == Keys.Down)

            {
                int x = 0, y = 0;

                movejudge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j + 1 <=3 && a[j, i] > 0)
                        {
                            x = j; y = i;
                            while (x + 1 <=3 && a[x + 1, y] == 0 && a[x, y] > 0)
                            {
                                a[x+1 , y] = a[x, y]; a[x, y] = 0;
                                x++;
                                movejudge = true;
                            }
                        }
                    }
                    for (int j = 3; j>=0; j--)
                    {
                        if (j -1 >=0 && a[j, i] == a[j - 1, i])
                        {
                            a[j, i] = a[j, i] * 2; a[j - 1, i] = 0;
                            score = score + a[j, i];
                        }
                    }
                    for (int j = 0; j < 4; j++)
                    {
                        if (j + 1 <= 3 && a[j, i] > 0)
                        {
                            x = j; y = i;
                            while (x + 1 <=3 && a[x + 1, y] == 0 && a[x, y] > 0)
                            {
                                a[x + 1, y] = a[x, y]; a[x, y] = 0;
                                x++;
                                movejudge = true;
                            }
                        }
                    }
                }


                judge = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            judge = true;
                            break;
                        }
                    }
                }
                if (judge == true && movejudge == true)
                {
                    judge = false;
                    while (judge == false)
                    {
                        x = random1.Next() % 4; y = random1.Next() % 4;
                        if (a[x, y] == 0)
                        {
                            a[x, y] = 2;
                            judge = true;
                        }

                    }
                }


                int count = 0;  //顯示方塊

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (a[i, j] == 0)
                        {
                            piclist[count].Image = new Bitmap("0.png");
                            count++;
                        }
                        if (a[i, j] == 2)
                        {
                            piclist[count].Image = new Bitmap("2.png");
                            count++;
                        }
                        if (a[i, j] == 4)
                        {
                            piclist[count].Image = new Bitmap("4.png");
                            count++;
                        }
                        if (a[i, j] == 8)
                        {
                            piclist[count].Image = new Bitmap("8.png");
                            count++;
                        }
                        if (a[i, j] == 16)
                        {
                            piclist[count].Image = new Bitmap("16.png");
                            count++;
                        }
                        if (a[i, j] == 32)
                        {
                            piclist[count].Image = new Bitmap("32.png");
                            count++;
                        }
                        if (a[i, j] == 64)
                        {
                            piclist[count].Image = new Bitmap("64.png");
                            count++;
                        }
                        if (a[i, j] == 128)
                        {
                            piclist[count].Image = new Bitmap("128.png");
                            count++;
                        }
                        if (a[i, j] == 256)
                        {
                            piclist[count].Image = new Bitmap("256.png");
                            count++;
                        }
                        if (a[i, j] == 512)
                        {
                            piclist[count].Image = new Bitmap("512.png");
                            count++;
                        }
                        if (a[i, j] == 1024)
                        {
                            piclist[count].Image = new Bitmap("1024.png");
                            count++;
                        }
                        if (a[i, j] == 2048)
                        {
                            piclist[count].Image = new Bitmap("2048.png");
                            count++;
                        }
                    }

                }
                label3.Text = Convert.ToString(score);

                Boolean judge2 = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 0 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 3 && j == 0)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左下角
                            {
                                judge2 = true;
                                break;
                            }
                        }

                        else if (i == 3 && j == 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i - 1, j])) //右上角
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 0 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j])) //左右下
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 0 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //上下右
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (i == 3 && j > 0 && j < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i - 1, j])) //左右上
                            {
                                judge2 = true;
                                break;
                            }
                        }


                        else if (j == 3 && i > 0 && i < 3)
                        {
                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //上下左
                            {
                                judge2 = true;
                                break;
                            }
                        }
                        else

                            if ((a[i, j] == 0) || (a[i, j] == a[i, j - 1]) || (a[i, j] == a[i, j + 1]) || (a[i, j] == a[i + 1, j]) || (a[i, j] == a[i - 1, j])) //左右下
                        {
                            judge2 = true;
                            break;
                        }


                    }
                }


                if (judge2 == false)
                {      
                    if (score > Convert.ToInt32(System.IO.File.ReadAllText(@"best.txt")))
                        System.IO.File.WriteAllText(@"best.txt", Convert.ToString(score));
                    if (MessageBox.Show("GAME OVER", "2048") == DialogResult.OK)
                    {
                        Close();
                    }
                }
            }
        }

    }
}
