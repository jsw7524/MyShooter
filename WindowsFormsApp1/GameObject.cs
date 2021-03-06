﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class GameObject
    {
        public int ID { get; }
        static int number;
        public int HP { get; set; }
        //public int Speed { get; set; }
        //public int X { get; set; }
        //public int Y { get; set; }
        //protected int Height { get; set; }
        //protected int Width { get; set; }

        public GameObject(int hp)
        {
            //this.X = x;
            //this.Y = y;
            //this.Width = width;
            //this.Height = height;
            //this.Speed = speed;
            this.HP = hp;
            ID = number;
            number++;
            GameMgr.GameObjects.Add(this);
        }

        public virtual void DoSomething()
        {


        }

        public void IsDeleted()
        {
            if (HP <= 0)
            {
                if (this is VisibleGameObject)
                {
                    var g = this as VisibleGameObject;
                    foreach (var p in g.Contour)
                    {
                        GameMgr.GameObjectDictionary.Remove(p);
                    }
                }
                GameMgr.GameObjects.Remove(this);
            }

        }

    }
}
