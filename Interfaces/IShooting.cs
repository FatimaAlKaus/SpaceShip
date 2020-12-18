using System;

namespace Game
{
    internal interface IShooting
    {
         event Action<Bullet> FireNotify;
        void Fire();
       
    }
}