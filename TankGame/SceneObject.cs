using System.Collections.Generic;
using System.Diagnostics;

namespace Project2D
{


    public class SceneObject
    {
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();
        public SceneObject Parent
        {
            get { return parent; }
        }
        public SceneObject()
        {
        }

        /// <summary>
        /// Destructor clear out references of this object from parents
        /// and children.
        /// </summary>
        ~SceneObject()
        {
            if (parent != null)
            {
                parent.RemoveChild(this);
            }
            foreach (SceneObject so in children)
            {
                so.parent = null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> The length of the children list </returns>
        public int GetChildCount()
        {
            return children.Count;
        }

        /// <summary>
        /// Easily grab child by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>The child SceneObject </returns>
        public SceneObject GetChild(int index)
        {
            return children[index];
        }

        /// <summary>
        /// Adds the passed SceneObject to the children list
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(SceneObject child)
        {
            // make sure it doesn't have a parent already
            Debug.Assert(child.parent == null);
            // assign "this as parent
            child.parent = this;
            // add new child to collection
            children.Add(child);
        }

        /// <summary>
        /// Removes the SceneObject child from the children list
        /// </summary>
        /// <param name="child"></param>
        public void RemoveChild(SceneObject child)
        {
            if (children.Remove(child) == true)
            {
                child.parent = null;
            }
        }




    }
}