using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class ScaleTransform
    {
        [MenuItem("GameObject/ScaleTransform", false, -1)]
        static void DoScaleTransform()
        {
            foreach (var t in Selection.transforms)
            {
                t.position /= 100;
            }
        }
    }
}