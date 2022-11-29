using System;
using System.Drawing;

namespace AsteroidGameApp
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }
}
