﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Toggle
{
    class Player : Creature
    {
        KeyboardState oldKeyBoardState;

        public Player(int xLocation, int yLocation, bool initialState) : base(xLocation, yLocation, initialState)
        {
            goodGraphic = Textures.textures["player"];
            badGraphic = Textures.textures["player"];
            imageBoundingRectangle = new Rectangle(0, 0, 32, 32);
            width = 32;
            height = 32;
        }


        public override void move(ArrayList colidables)
        {
            KeyboardState newKeyBoardState = Keyboard.GetState();
            if (newKeyBoardState.IsKeyDown(Keys.Up))
            {
                if (checkCollision(colidables, 0, +velocity) == true)
                    y -= velocity;
            }
            else if (newKeyBoardState.IsKeyDown(Keys.Down))
            {
                if (checkCollision(colidables, 0, -velocity) == true)
                    y += velocity;
            }
            else if (newKeyBoardState.IsKeyDown(Keys.Left))
            {
                if (checkCollision(colidables, velocity, 0) == true)
                     x -= velocity;
            }
            else if (newKeyBoardState.IsKeyDown(Keys.Right))
            {
                if (checkCollision(colidables, -velocity, 0) == true)
                    x += velocity;
            }

            oldKeyBoardState = newKeyBoardState;
            hitBox = new Rectangle(x, y, width, height);
        }
        bool checkCollision(ArrayList collidables,int xdiff, int ydiff)
        {
            bool canMove = true;
            foreach (Creature c in collidables)
            {
                if (c != this)
                {
                    Rectangle otherRect = c.getHitBox();
                    otherRect.X += xdiff;
                    otherRect.Y += ydiff;
                    if (otherRect.Intersects(getHitBox()))
                    {
                        canMove = false;
                    }
                }
            }
            return canMove;
        }

        public void pickUp(Item i)
        {

        }
    }
}
