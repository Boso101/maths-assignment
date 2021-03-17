using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;

namespace Project2D
{
    /// <summary>
    /// Base class for all game objects in tank game including the world
    /// </summary>
    public abstract class BaseEntity
    {

        protected Vector2 position;
        protected float rotation = 0;
        protected BaseEntity parent = null;



        protected List<BaseEntity> children = new List<BaseEntity>();



        public Vector2 Position { get => position; set => position = value; }
        public float Rotation { get => rotation; set => rotation = value; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseEntity()
        {
            position = new Vector2(0, 0);

            Draw();
        }


        /// <summary>
        /// Constructor with position only
        /// </summary>
        public BaseEntity(Vector2 position)
        {
            this.position = position;
            Draw();


        }

        /// <summary>
        /// Constructor with position and parent
        /// </summary>
        /// <param name="position"></param>
        /// <param name="parent"></param>
        public BaseEntity(Vector2 position, BaseEntity parent)
        {
            this.position = position;
            this.parent = parent;

            Draw();

        }


        /// <summary>
        /// Constructor with parent
        /// </summary>
        /// <param name="parent"></param>
        public BaseEntity(BaseEntity parent)
        {
            position = new Vector2(0, 0);
            children = new List<BaseEntity>();
            this.parent = parent;

            Draw();


        }

        /// <summary>
        /// Constructor with spawnPos, children and parent
        /// </summary>
        /// <param name="spawnPosition"></param>
        /// <param name="children"></param>
        /// <param name="parent"></param>
        public BaseEntity(Vector2 spawnPosition, List<BaseEntity> children, BaseEntity parent = null)
        {
            position = spawnPosition;
            this.parent = parent;
            this.children = children;

            Draw();


        }

        /// <summary>
        /// Add a child to this entity
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(BaseEntity child)
        {
            children.Add(child);
        }

        /// <summary>
        /// Remove child from this entity
        /// </summary>
        /// <param name="child"></param>
        public void RemoveChild(BaseEntity child)
        {
            children.Remove(child);
        }

        /// <summary>
        /// Sets the objects parent
        /// </summary>
        /// <param name="parent"></param>
        public void SetParent(BaseEntity parent)
        {
            this.parent = parent;
        }


        /// <summary>
        /// Removes the objects parent
        /// </summary>
        public void RemoveParent()
        {
            parent = null;
        }


        /// <summary>
        /// Draw function for this object
        /// </summary>
        public abstract void Draw();



    } 
}
