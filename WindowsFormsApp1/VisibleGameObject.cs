﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class VisibleGameObject : GameObject
    {
        public int Speed { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        protected int Height { get; set; }
        protected int Width { get; set; }
        public VisibleGameObject(int x, int y, int width, int height, int speed, int hp) : base(hp)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;

            Contour.Add(new Point(this.X, this.Y));
            Contour.Add(new Point(this.X, this.Y + this.Height));
            Contour.Add(new Point(this.X + this.Width, this.Y));
            Contour.Add(new Point(this.X + this.Width, this.Y + this.Height));
            /////////////
            //Contour.Add(new Point(this.X, this.Y + this.Height/2));
            //Contour.Add(new Point(this.X + this.Width / 2, this.Y));
            //Contour.Add(new Point(this.X + this.Width / 2, this.Y + this.Height / 2));
            ////////////////
            //Contour.Add(new Point(this.X + this.Width, this.Y + this.Height / 2));
            //Contour.Add(new Point(this.X + this.Width / 2, this.Y + this.Height));
            //////////
            SetGraph();
            foreach (var p in this.Contour)
            {
                GameMgr.GameObjectDictionary.Add(p, this);
            }
        }

        public int TopLeftX { get; set; }
        public int TopLeftY { get; set; }
        public int BottomRightX { get; set; }
        public int BottomRightY { get; set; }

        public List<Point> Contour { get; set; } = new List<Point>();

        public virtual void SetGraph()
        {
            TopLeftX = this.X;
            TopLeftY = this.Y;
            BottomRightX = this.X + this.Width;
            BottomRightY = this.Y + this.Height;
            //////////////
            Contour[0].X = this.X;
            Contour[0].Y = this.Y;
            Contour[1].X = this.X;
            Contour[1].Y = this.Y + this.Height;
            Contour[2].X = this.X + this.Width;
            Contour[2].Y = this.Y;
            Contour[3].X = this.X + this.Width;
            Contour[3].Y = this.Y + this.Height;
            ///////////////
        }

        public virtual List<GameObject> IsHit()
        {
            var ps = GameMgr.GameDataStructure.Search_KD_Tree(GameMgr.KdRoot, TopLeftX, TopLeftY, BottomRightX, BottomRightY);

            bool isDeleted = false;

            foreach (var p in ps)
            {
                var gobj = GameMgr.GameObjectDictionary[p];
                if (gobj == this)
                {
                    continue;
                }
                else if (gobj is Bullet)
                {
                    var bullet = gobj as Bullet;
                    HP -= 1;
                    bullet.HP = -1;
                }
                else if (gobj is MyShip)
                {
                    var myShip = gobj as MyShip;
                    HP -= 1;

                    gobj.HP -= 1;
                }
            }

            return null;
        }
    }
    
}