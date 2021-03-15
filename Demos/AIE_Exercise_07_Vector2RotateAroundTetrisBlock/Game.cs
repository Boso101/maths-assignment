using MathClasses;
using Raylib_cs;
using System;

namespace AIE_Exercise_07_Vector2RotateAroundTetrisBlock
{
    class Block
    {
        public const float BlockSize = 32;

        public Shape parent = null;
        public Vector2 pos;

        public Block(Shape parent, Vector2 pos)
        {
            this.pos = pos;
            this.parent = parent;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            float hbs = BlockSize / 2.0f;
            Rectangle rect = new Rectangle(pos.x - hbs + 1, pos.y - hbs + 1, BlockSize - 2, BlockSize - 2);
            Raylib.DrawRectangleRounded(rect, 0.25f, 8, Color.BLUE);
        }
    }

    class Shape
    {
        public Vector2 pos;
        public Block[] blocks = new Block[4];

        public static Shape CreateTShape(Vector2 pos)
        {
            Shape shape = new Shape(pos);

            float bs = Block.BlockSize;
            shape.blocks[0] = new Block(shape, pos + new Vector2(0 * bs, 0 * bs));
            shape.blocks[1] = new Block(shape, pos + new Vector2(-1 * bs, 0 * bs));
            shape.blocks[2] = new Block(shape, pos + new Vector2(1 * bs, 0 * bs));
            shape.blocks[3] = new Block(shape, pos + new Vector2(0 * bs, 1 * bs));

            return shape;
        }

        public void RotateShape(float amount)
        {
            foreach (var block in blocks)
            {
                block.pos.RotateAround(pos, amount);
            }
        }

        public Shape(Vector2 pos)
        {
            this.pos = pos;
        }

        public void Update()
        {

        }

        public void Draw()
        {
            foreach (var block in blocks)
            {
                block.Draw();
            }
            Raylib.DrawCircle((int)pos.x, (int)pos.y, 2, Color.BLACK);
        }
    }

    class Game : IGameState
    {
        Shape shape;

        public Game(Program program) : base(program)
        {
            shape = Shape.CreateTShape(new Vector2(400, 225));
        }

        public override void Update()
        {
            shape.Update();

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                shape.RotateShape(MathF.PI * Raylib.GetFrameTime());

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN))
                shape.RotateShape(MathF.PI / 2.0f);
        }

        public override void Draw()
        {
            shape.Draw();
        }
    }
}
