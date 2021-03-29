using MathClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public interface IMoveable
    { 
        float MovementSpeed { get; }
        void Move(Vector3 dir, float deltaTime);
    
    }

}
