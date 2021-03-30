﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2D
{
    public interface IBot
    {
         bool AIControlled { get; }

        void Think(float deltaTime);

    }
}
