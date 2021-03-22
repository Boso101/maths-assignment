using MathClasses;
using System.Collections.Generic;
using System.Diagnostics;
using Raylib;
using static Raylib.Raylib;

namespace Project2D
{

    /// <summary>
    /// Base Parent class for most if not all objects we will use.
    /// It is pretty much the GameObject class from Unity
    /// </summary>
    public class SceneObject
    {
        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();

        protected string objectName = "";


      
        protected Matrix3 localTransform = new Matrix3();
        
     
        protected Matrix3 globalTransform = new Matrix3();


        public Matrix3 LocalTransform
        {
            get { return localTransform; }
        }
        public Matrix3 GlobalTransform
        {
            get { return globalTransform; }
        }

        public string ObjectName { get => objectName; }




        public SceneObject Parent
        {
            get { return parent; }
        }
        public SceneObject()
        {
            objectName = "Scene Object";
        }

        public SceneObject(string name)
        {
            objectName = name;
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
        /// Simpler coordinate display
        /// </summary>
        /// <returns></returns>
        public MathClasses.Vector3 GetCoordinates()
        {
            return new MathClasses.Vector3(globalTransform.X, globalTransform.Y, 0);
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

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime"></param>
        public void Update(float deltaTime)
        {
            // run OnUpdate behaviour
            OnUpdate(deltaTime);
            // update children
            foreach (SceneObject child in children)
            {
                child.Update(deltaTime);
            }
        }

        /// <summary>
        /// Draws the object 
        /// </summary>
        public void Draw()
        {
            // run OnDraw behaviour
            OnDraw();
            // draw children
            foreach (SceneObject child in children)
            {
                child.Draw();
            }
        }

        /// <summary>
        /// Called on every update tick
        /// Custom logic for children of this class
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void OnUpdate(float deltaTime)
        {
      
        }

        /// <summary>
        /// Called on draw
        /// Custom logic for children of this class
        /// </summary>
        public virtual void OnDraw()
        {
#if DEBUG

            DrawText(objectName + " Local", (int)localTransform.X, (int)localTransform.Y, 12, Color.GREEN);
            DrawText(objectName + " Global", (int)globalTransform.X, (int)globalTransform.Y, 12, Color.GREEN);
#endif
        }

        /// <summary>
        /// constantly updates both global and local transform data
        /// </summary>
        public void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;

            // Foreach loop that calls this on children
            foreach (SceneObject child in children)
                child.UpdateTransform();
        }






        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y);
            UpdateTransform();
        }
        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }
        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }
        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y);
            UpdateTransform();
        }
        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }
        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }





        /// <summary>
        /// Debug ToString Method
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return $"Parent: {parent?.objectName}\nSceneObject: {objectName}\nLocalCoordinates: {localTransform.GetColumn(1)}\nGlobalCoordinates: {globalTransform.GetColumn(1)}";
        }

    }
}