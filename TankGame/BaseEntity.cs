using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;

namespace Project2D
{
    public abstract class BaseEntity
    {

        protected Vector2 position;
        protected BaseEntity parent;
        protected List<BaseEntity> children;



        public BaseEntity()
        {
            position = new Vector2(0, 0);
            parent = null;

        }

        public BaseEntity(Vector2 spawnPosition, BaseEntity parent = null)
        {
            position = spawnPosition;
            this.parent = parent;
            
        }
        
    } 
}
