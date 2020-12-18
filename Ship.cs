using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ship : GameObject, IDrawable, IShooting
    {
        private int counterTick = 0;
        public int MaxHP { get; set; } = 100;
        private int _health;
        public decimal Score { get; set; }

        public int AttackSpeed { get; set; } = 15;//Чем меньше - тем быстрее
        public Size BulletSize { get; set; } = new Size(10, 10);
        public int Health
        {
            get => _health;
            set
            {

                _health = value;
                if (_health > MaxHP)
                {
                    _health = MaxHP;
                }
            }
        }
        public override Size Size { get; set; } = new Size(30, 30);
        public int Damage { get; set; } = 40;

        public event Action<Bullet> FireNotify;
        public Ship()
        {
            Health = MaxHP;
        }

        public void Draw(Graphics graphics)
        {

            graphics.FillRectangle(new SolidBrush(Color.Red), 5, 5, Health, 10);   //ХП
            graphics.DrawRectangle(new Pen(Color.Black, 2), 5, 5, MaxHP, 10);     //ХП


            graphics.DrawRectangle(new Pen(Color.Red, 1), Rectangle);
        }

        public void Fire()
        {
            counterTick++;
            if (counterTick >= AttackSpeed)
            {
                FireNotify?.Invoke(new Bullet(Rectangle, BulletSize));
                counterTick = 0;
            }
        }
    }
}
