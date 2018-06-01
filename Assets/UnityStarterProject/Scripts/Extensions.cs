using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStarterProject.Extensions
{
    public static class Extensions
    {
        /// <summary>
        /// Grabs all parents of a transform
        /// </summary>
        /// <param name="transform">The transform this is called on</param>
        /// <param name="includeSelf">If true, includes the transform this is called on</param>
        /// <returns></returns>
        public static List<Transform> GetAllParents(this Transform transform, bool includeSelf = true)
        {
            List<Transform> parents = new List<Transform>();

            Transform parent = transform;

            if (includeSelf)
            {
                parents.Add(parent);
            }

            while(parent.parent != null)
            {
                parents.Add(parent.parent);

                parent = parent.parent;
            }

            return parents;
        }
    }
}