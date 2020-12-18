using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Boss : Enemy, IShooting
    {

        bool right = true;
        public int counterTick;
        public int MaxHP { get; private set; } = 3000;
        public int AttackSpeed { get; set; } = 5;//Чем меньше - тем быстрее
        public Boss(Point point, int maxHp, int speed, int damage, int attackSpeed) : base(point, speed, maxHp)
        {
            Size = new Size(100, 100);
            MaxHP = maxHp;
            Health = MaxHP;
            Damage = damage;
            AttackSpeed = attackSpeed;
        }

        public event Action<Bullet> FireNotify;

        public override void Draw(Graphics graphics)
        {
            //graphics.DrawImage(Resource1.EnemyShip, Rectangle);
            graphics.DrawRectangle(new Pen(Color.Red, 4), Rectangle);
            graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(new Point(Location.X - Health / 2 + Size.Width / 2, Location.Y - 10), new Size(Health, 10)));
        }

        public void Fire()
        {
            if (counterTick == AttackSpeed)
            {
                FireNotify?.Invoke(new Bullet(Rectangle, new Size(10, 10), true, 10));
                counterTick = 0;
            }
        }

        public override void Fly(int width = 0)
        {

            if (right)
                if (Location.X <= width - Size.Width / 2)
                    Location = new Point(Location.X + Speed, Location.Y);
                else
                {
                    right = false;

                }
            else
            {
                if (Location.X >= -Size.Width / 2)
                    Location = new Point(Location.X - Speed, Location.Y);
                else
                {
                    right = true;

                }
            }
        }
    }
}

