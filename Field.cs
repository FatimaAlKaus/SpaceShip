using Game.Boxes;
using Game.Boxes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Field : IDrawable
    {
        public List<Box> boxes = new List<Box>();
        public List<Enemy> enemies = new List<Enemy>();
        public List<Bullet> bullets = new List<Bullet>();
        public List<Bullet> enemyBullets = new List<Bullet>();

        int bossSpeed = 10;
        int bossHealth = 1000;
        int bossAttackSpeed = 10;

        int enemyHealth = 100;

        public event Action GameOver;
        Boss boss;
        public Ship ship;
        int CountSpawn = 50;  //Спавнит врага, когда счетчик достигает это число
        int CountBossSpawn = 2000;
        int bossCount = 0;
        int count = 0;
        int Width;
        int Height;
        public Field(Ship ship, int width, int height)
        {
            Width = width;
            Height = height;
            this.ship = ship;
            ship.FireNotify += (bullet) => { bullets.Add(bullet); };

        }
        public void Tick()
        {

            if (boss != null)
            {
                boss.counterTick++;
                boss?.Fire();
                boss?.Fly(Width);
            }
            foreach (var enemy in enemies)
            {
                enemy.Fly();
            }
            foreach (var bullet in bullets)
            {
                bullet.Fly();
            }
            foreach (var bullet in enemyBullets)
            {
                bullet.Fly();
            }
            foreach (var box in boxes)
            {
                box.Fly();
            }
            if (count >= CountSpawn)
            {
                Random random = new Random();

                Enemy enemy = new Enemy(new Point(random.Next(0, Width - 50), 0), random.Next(2, 5),enemyHealth); // Нужен размер врага

                enemies.Add(enemy);

                count = 0;
            }
            if (boss == null && bossCount >= CountBossSpawn)
            {
                boss = new Boss(new Point(Width / 2, 20), bossHealth, bossSpeed, 10, bossAttackSpeed);
                boss.FireNotify += (bullet) => { enemyBullets.Add(bullet); };
                bossCount = 0;
            }
            if (boss == null)
                bossCount++;
            count++;
            Logic();

        }
        private void Logic()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].Location.Y > Height || enemies[i].Health <= 0)
                {
                    Random random = new Random();
                    var result = random.Next(0, 100);
                    if (result >= 90)
                    {
                        boxes.Add(new HealthBox(enemies[i].Location));
                    }
                    if (result == 1 || result == 2)
                    {
                        boxes.Add(new MaxHPBox(enemies[i].Location));

                    }
                    if (result == 3 || result == 4)
                    {
                        boxes.Add(new DamageUpBox(enemies[i].Location));

                    }
                    if (result == 5 || result == 6)
                    {
                        boxes.Add(new BulletSizeBox(enemies[i].Location));
                    }
                    if (result == 7 || result == 8)
                    {
                        boxes.Add(new AttackSpeedBox(enemies[i].Location));
                    }
                    if (result == 9 || result == 10)
                    {
                        boxes.Add(new BoxUp(enemies[i].Location));
                    }
                    if (result == 11)
                    {
                        boxes.Add(new BigHealthBox(enemies[i].Location));

                    }
                    ship.Score += enemyHealth;
                    enemies.RemoveAt(i);

                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                //if (enemies[i].Rectangle.Contains(ship.Location) ||
                //    enemies[i].Rectangle.Contains(new Point(ship.Location.X + ship.Size.Width, ship.Location.Y)) ||
                //    enemies[i].Rectangle.Contains(new Point(ship.Location.X + ship.Size.Width, ship.Location.Y + ship.Size.Height)) ||
                //    enemies[i].Rectangle.Contains(new Point(ship.Location.X, ship.Location.Y + ship.Size.Height))
                //    ) //Везде бы так// ТУт ошибка какая-то
                if (enemies[i].Rectangle.IsCrossed(ship.Rectangle))
                {
                    ship.Health -= enemies[i].Damage;
                    ship.Score += enemyHealth/2;
                    enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].Location.Y < 0)
                {
                    bullets.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (enemyBullets[i].Location.Y > Height)
                {
                    enemyBullets.RemoveAt(i);
                }
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].Location.Y < 0)
                {
                    boxes.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    if (enemies[i].Rectangle.IsCrossed(bullets[j].Rectangle) || bullets[j].Rectangle.IsCrossed(enemies[i].Rectangle))

                    //    (
                    //enemies[i].Rectangle.Contains(ship.Location) ||
                    //enemies[i].Rectangle.Contains(new Point(bullets[j].Location.X + bullets[j].Size.Width, bullets[j].Location.Y)) ||
                    //enemies[i].Rectangle.Contains(new Point(bullets[j].Location.X + bullets[j].Size.Width, bullets[j].Location.Y + bullets[j].Size.Height)) ||
                    //enemies[i].Rectangle.Contains(new Point(bullets[j].Location.X, bullets[j].Location.Y + bullets[j].Size.Height))
                    //  )
                    {
                        bullets.RemoveAt(j);
                        enemies[i].Health -= ship.Damage;
                    }
                }
            }
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (ship.Rectangle.Contains(enemyBullets[i].Rectangle))
                {
                    if (boss != null)
                        ship.Health -= boss.Damage;
                    enemyBullets.RemoveAt(i);
                }
            }
            for (int i = 0; i < boxes.Count; i++)
            {
                if (boxes[i].Rectangle.IsCrossed(ship.Rectangle))

                //if (boxes[i].Rectangle.Contains(ship.Location) ||
                //    boxes[i].Rectangle.Contains(new Point(ship.Location.X + ship.Size.Width, ship.Location.Y)) ||
                //    boxes[i].Rectangle.Contains(new Point(ship.Location.X + ship.Size.Width, ship.Location.Y + ship.Size.Height)) ||
                //    boxes[i].Rectangle.Contains(new Point(ship.Location.X, ship.Location.Y + ship.Size.Height))
                //    )
                {
                    ship.Score += 10;
                    boxes[i].Use(ship);
                    boxes.RemoveAt(i);
                }
            }
            if (boss != null)
            {
                for (int j = 0; j < bullets.Count; j++)
                {
                    if (boss.Rectangle.IsCrossed(bullets[j].Rectangle) || bullets[j].Rectangle.IsCrossed(boss.Rectangle))
                    {
                        boss.Health -= ship.Damage;
                        bullets.RemoveAt(j);
                    }
                }
                if (boss.Health <= 0)
                {
                    ship.Score += boss.MaxHP;
                    boss = null;

                    bossSpeed += bossSpeed / 2;
                    if (bossSpeed > 60)
                        bossSpeed = 60;
                    bossHealth += bossHealth / 2;
                    bossAttackSpeed -= 2;
                    if (bossAttackSpeed < 1) bossAttackSpeed = 1;

                    CountSpawn--;
                    if (CountSpawn < 1) CountSpawn = 1;
                    enemyHealth += enemyHealth / 2;
                }
            }
            if (ship.Health <= 0)
                GameOver?.Invoke();
        }

        public void Draw(Graphics graphics)
        {
            boss?.Draw(graphics);
            ship.Draw(graphics);
            foreach (var enemy in enemies)
            {
                enemy.Draw(graphics);
            }
            foreach (var bullet in bullets)
            {
                bullet.Draw(graphics);
            }
            foreach (var bullet in enemyBullets)
            {
                bullet.Draw(graphics);
            }
            foreach (var box in boxes)
            {
                box.Draw(graphics);
            }

        }
    }
}
