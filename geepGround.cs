using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GeepGameOk
{
    public partial class geepGround : Form
    {
        //Variables
        private bool is_resized = false;
        private int ground_speed = 2;
        List<PictureBox> my_ground;
        List<PictureBox> my_obstacles;
        private int ground_width = 744;
        private int ground_height = 631;
        private int level =1;
        private int increase_level = 0;
        private bool movement_locked = false;
        private int coints = 0;

        //Initialise form
        public geepGround()
        {
            InitializeComponent();
            my_ground = new List<PictureBox>();

            //Add all the moving ground
            my_ground.Add(pictureBox3);
            my_ground.Add(pictureBox4);
            my_ground.Add(pictureBox5);
            my_ground.Add(pictureBox6);
            my_ground.Add(pictureBox7);
            my_ground.Add(pictureBox8);
            my_ground.Add(pictureBox9);
            my_ground.Add(pictureBox10);
            my_ground.Add(pictureBox11);
            my_ground.Add(pictureBox12);

            //Set player to start in the middle of the map

            player.Location = new Point((ground_width / 2) - (player.Width / 2),
                ground_height - player.Height - 100);

            //Spawn enemies
            my_obstacles = new List<PictureBox>();
            my_obstacles.Add(pictureBox15);
            my_obstacles.Add(pictureBox16);
            var random_location = new Random();
            foreach (var enemy in my_obstacles)
            {
                enemy.Location = new Point(random_location.Next(10, ground_width - pictureBox15.Width - 10),
                    random_location.Next(20, ground_height / 2 - 60));

            }

            //Hide game_over display
            label6.Visible = false;

            //Display Coin
            pictureBox17.Location = new Point(random_location.Next(10, ground_width - 100),
                random_location.Next(20, ground_height / 2 - 100));
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(is_resized == false )
            {
                //Resize game and center it
                this.Width = this.Width * 2;
                ground_width = this.Width;
                is_resized = true;
                this.CenterToScreen();

                //Move buttons
                pictureBox1.Location = new Point(pictureBox1.Location.X * 2 + 45,
                    pictureBox1.Location.Y);
                pictureBox2.Location = new Point(pictureBox2.Location.X * 2 + 85,
                    pictureBox2.Location.Y);
               foreach(var element in my_ground)
                {
                    element.Location = new Point(element.Location.X * 2, element.Location.Y);
                }
                pictureBox13.Location = new Point(pictureBox13.Location.X * 2 + 30, pictureBox13.Location.Y);

                //Move HUD
                label2.Location = new Point(label2.Location.X * 2, label2.Location.Y);
                label3.Location = new Point(label3.Location.X * 2 + 35, label3.Location.Y);
                label4.Location = new Point(label4.Location.X * 2, label4.Location.Y);
                label5.Location = new Point(label5.Location.X * 2, label5.Location.Y);

                //Move Player, Enemies, Coin
                player.Location = new Point(player.Location.X * 2, player.Location.Y);
                pictureBox15.Location = new Point(pictureBox15.Location.X * 2, pictureBox15.Location.Y);
                pictureBox16.Location = new Point(pictureBox16.Location.X * 2, pictureBox16.Location.Y);
                pictureBox17.Location = new Point(pictureBox17.Location.X * 2, pictureBox17.Location.Y);
            }
            else if(is_resized == true)
            {
                //Resize game and center it
                this.Width = this.Width / 2;
                ground_width = this.Width;
                is_resized = false;
                this.CenterToScreen();
                //Move buttons
                pictureBox1.Location = new Point((pictureBox1.Location.X - 45) / 2, pictureBox1.Location.Y);
                pictureBox2.Location = new Point((pictureBox2.Location.X - 85) / 2, pictureBox2.Location.Y);
                foreach(var element in my_ground)
                {
                    element.Location = new Point(element.Location.X / 2, element.Location.Y);
                }
                pictureBox13.Location = new Point((pictureBox13.Location.X - 30) / 2, pictureBox13.Location.Y);

                //Move HUD
                label2.Location = new Point(label2.Location.X / 2, label2.Location.Y);
                label3.Location = new Point((label3.Location.X - 35) / 2, label3.Location.Y);
                label4.Location = new Point(label4.Location.X / 2, label4.Location.Y);
                label5.Location = new Point(label5.Location.X / 2, label5.Location.Y);

                //Move Player, Enemies, Coin
                player.Location = new Point(player.Location.X / 2, player.Location.Y);
                pictureBox15.Location = new Point(pictureBox15.Location.X / 2, pictureBox15.Location.Y);
                pictureBox16.Location = new Point(pictureBox16.Location.X / 2, pictureBox16.Location.Y);
                pictureBox17.Location = new Point(pictureBox17.Location.X / 2, pictureBox17.Location.Y);
            }

           //Close button

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Call ground movement every tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("dd/MMM/yyyy");
            
            //Move Obstacles and Ground
            line_speedUp(ground_speed);
            obstacles_speedUp(ground_speed);
            coin_speedUp();
            coin_display();

            //Periodically increase difficulty
            increase_level++;
            if(increase_level == 500)
            {
                level++;
                increase_level = 0;
                if (ground_speed < 18)
                    ground_speed += 2;
            }
            // Display Coins, speed and level
            label3.Text = level.ToString();
            label5.Text = ground_speed.ToString() + "km/h";
            label8.Text = coints.ToString();
        }
        
        //Move ground
        private void line_speedUp(int speed)
        {
            //Check if the game is still running
            if (movement_locked == true)
                return;
            //Move everything down
            foreach(var element in my_ground)
            {
                element.Top += speed;
                //If the element leaves the border, put it back up
                if(element.Location.Y > 631 - element.Height)
                {
                    element.Location = new Point(element.Location.X, element.Location.Y - 650);
                }
            }
        }
        // Player Controls
        private void geepGround_KeyDown(object sender, KeyEventArgs e)
        {
            //Check if the game is still running
            if (movement_locked == true)
                return;
            //Speed UP/Down and go LEFT/RIGHT
            if (e.KeyCode == Keys.W)
            {
                if (ground_speed <= 16)
                    ground_speed += 2;
            }
            else if (e.KeyCode == Keys.A)
            {
                if (player.Location.X > 10)
                    player.Location = new Point(player.Location.X - 10, player.Location.Y);
            }
            else if(e.KeyCode == Keys.D)
            {
                if (player.Location.X < ground_width - player.Width - 28)
                    player.Location = new Point(player.Location.X + 10, player.Location.Y);
            }
            else if(e.KeyCode == Keys.S)
            {
                if (ground_speed > 3 && ground_speed > level + 3)
                    ground_speed -= 2;
            }
        }
        //Move the obstacles
        private void obstacles_speedUp(int speed)
        {
            //Check if the game is still running
            if (movement_locked == true)
                return;
            foreach(var obstacle in my_obstacles)
            {
                obstacle.Top += speed / 2;
                //Check if we are still on the map
                if (obstacle.Top > ground_width - obstacle.Height)
                {
                    var random_location = new Random();
                    obstacle.Location = new Point(random_location.Next(10, ground_width - pictureBox15.Width - 10), 50);

                }
                    //Check collision with player
                    if(player.Bounds.IntersectsWith (obstacle.Bounds))
                    {
                        timer1.Enabled = false;
                        game_over();
                    }
            }
        }
       
        //Game Over Screen
        private void game_over()
        {
            //Stop ground from moving
            ground_speed = 0;
            movement_locked = true;

            //Display game_over screen
            label6.Visible = true;
        }

        //Move Coin
        private void coin_speedUp()
        {
            var random_location = new Random();
            pictureBox17.Top += 2;
            if (pictureBox17.Location.Y > ground_height - pictureBox17.Height)
                pictureBox17.Location = new Point(random_location.Next(10, ground_width - 100), 10);
        }
        //Display Coin
        private void coin_display()
        {
            //Get random position
            var random_position = new Random();
            //Check player Collision
            if(player.Bounds.IntersectsWith(pictureBox17.Bounds))
            {
                //Display Coin
                var random_location = new Random();
                pictureBox17.Location = new Point(random_location.Next(10, ground_width - 100),random_position.Next(20, ground_height / 2 - 100));
                coints++;
            }
        }

        private void geepGround_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}

