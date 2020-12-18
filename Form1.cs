using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class Form1 : Form
    {

        Field field;
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new Size(Width, Height);
            this.MinimumSize = new Size(Width, Height);
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            UpdateStyles();
            Cursor.Hide();
            Ship ship = new Ship();
            field = new Field(ship, Width, Height);
            timer1.Tick += (a, b) =>
            {
                field.Tick();
                field.ship.Fire();
                Refresh();
                label1.Text = "Пулек " + field.bullets.Count.ToString();
                label2.Text = "Врагов " + field.enemies.Count.ToString();
                label3.Text = "Пули босса " + field.enemyBullets.Count.ToString();
                label5.Text = "Score: " + ship.Score.ToString();
                label5.BackColor = Color.Transparent;
                label4.Text = ship.Health.ToString();
                label4.BackColor = Color.Transparent;

                label4.Location = new Point(5 + ship.MaxHP / 2 - label4.Size.Width / 2, 4);// graphics.DrawRectangle(new Pen(Color.Black, 2), 5, 5, MaxHP, 10);

            };
            field.GameOver += Close;
            // MouseDown += (a, e) => { field.ship.Fire(); };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }




        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            field.ship.Location = new Point(e.X - field.ship.Size.Width / 2, e.Y - field.ship.Size.Height / 2);
            // Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            field.Draw(e.Graphics);

        }
    }
}
