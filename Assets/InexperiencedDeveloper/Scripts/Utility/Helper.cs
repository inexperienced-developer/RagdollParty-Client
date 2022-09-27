using UnityEngine;

namespace InexperiencedDeveloper.Utils
{
    public class Helper
    {
        public static float Round(float value, int digits)
        {
            float mult = Mathf.Pow(10.0f, (float)digits);
            return Mathf.Round(value * mult) / mult;
        }

        //public static Transform GetComponentInParentRecursive(T)
        //{
        //    if (obj.transform.parent != null)
        //    {
        //        return obj.transform.parent.GetComponentInParent<T>();
        //    }
        //    return null;
        //}
    }
}

