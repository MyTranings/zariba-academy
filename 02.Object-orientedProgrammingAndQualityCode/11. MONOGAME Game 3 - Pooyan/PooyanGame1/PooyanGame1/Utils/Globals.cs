using Microsoft.Xna.Framework;
using System;

namespace PooyanGame1.Utils
{
    public static class Globals
    {
        // Entity
        public const float ENTITY_SCALE = 1.9f;

        // Player
        public const int PLAYER_POSITION_X = 543;
        public const int PLAYER_POSITION_Y = 150;
        public const int PLAYER_MIN_POSITION_Y = 130;
        public const int PLAYER_MAX_POSITION_Y = 330;
        public const int PLAYER_SPEED = 5;

        // Enemy
        public const int ENEMY_MIN_POSITION_X = 130;
        public const int ENEMY_MAX_POSITION_X = 330;
        public const int ENEMY_MIN_SPEED = 2;
        public const int ENEMY_MAX_SPEED = 4;
        public const int ENEMY_MIN_POS_Y = 20;
        public const int ENEMY_MAX_POS_Y = 35;

        public const int GAME_WIDTH = 650;
        public const int GAME_HEIGHT = 480;

        // Rope
        public const int ROPE_POSITION_X = 570;
        public const int ROPE_POSITION_Y = 110;

        // Arrow
        public const int ARROW_RANGE_X = 30;

        public static readonly Vector2 ARROW_POSITION_OFFSET = new Vector2(-10, 20);
        public static readonly Random RNG = new Random();

        public const float GROUND_POSITION_Y = 420;

        public const int FIRST_RECTANGLE_TOP = 135;
        public const int FIRST_RECTANGLE_BOTTOM = 170;
        public const int RECTANGLE_OFFSET = 65;
        public static int BusyLadders = 0;

        public const int LADDER_POSITION_X = 590;
        public static readonly int[] LadderPositionsY = { 350, 285, 220, 160 };
    }
}
