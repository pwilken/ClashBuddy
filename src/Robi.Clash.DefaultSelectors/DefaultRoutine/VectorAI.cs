namespace Robi.Clash.DefaultSelectors
{
    using System;
    using System.Collections.Generic;

    public class Cast
    {
        public string SpellName = "";
        public VectorAI Position;
        public Handcard hc = new Handcard();

        public Cast(string spellName, VectorAI position, Handcard handCard)
        {
            this.SpellName = spellName;
            this.Position = position;
            this.hc = handCard;
        }

        public override string ToString()
        {
            return this.SpellName + " " + this.Position?.ToString();
        }
    }

    public class VectorAI
    {
        private int x = 0;
        private int y = 0;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public VectorAI(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public VectorAI(VectorAI copy)
        {
            x = copy.X;
            y = copy.Y;
        }

        public VectorAI(Engine.NativeObjects.Native.Vector2f pos)
        {
            x = (int)pos.X;
            y = (int)pos.Y;
        }

        public VectorAI(string s) //{3500/25500}
        {
            s = s.Substring(1, s.Length - 2);
            string[] ss = s.Split('/');
            x = Convert.ToInt32(ss[0]);
            y = Convert.ToInt32(ss[1]);
        }

        public Engine.NativeObjects.Native.Vector2f ToVector2f(bool needRandom)
        {
            int xPos = x;
            int yPos = y;
            if (needRandom)
            {
                Random rnd = new Random();
                int dX = xPos % 1000;
                if (dX > 500) dX = dX - 1000;
                xPos += rnd.Next(dX);

                int dY = yPos % 1000;
                if (dY > 500) dY = dY - 1000;
                yPos += rnd.Next(dY);
            }
            return new Engine.NativeObjects.Native.Vector2f(xPos, yPos);
        }

        //If ever will be is available real direction, speed, acceleration, then maybe all this can be changed to a Vector form
        public int getDistanceToTarget(VectorAI targetPosition)
        {
            return (int)Math.Sqrt((targetPosition.x - x) * (targetPosition.x - x) + (targetPosition.y - y) * (targetPosition.y - y));
        }

        public override string ToString()
        {
            return "{" + this.x + "/" + this.y + "}";
        }

        public void AddYInDirection(Playfield p, int y = 1000)
        {
            VectorAI moveVector = new VectorAI(0, y);
            if (p.home)
                this.Y -= (y * 4);
            else
                this.Y += y;
        }

        public void SubtractYInDirection(Playfield p, int y = 1000)
        {
            VectorAI moveVector = new VectorAI(0, y);
            if (p.home)
                this.Y += (y * 4);
            else
                this.Y -= y;
        }
    }
}