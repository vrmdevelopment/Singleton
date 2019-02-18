using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

/// <summary>
/// Extension methods for Unity's GameObject class
/// </summary>
public static class GameObjectExtensions
{

    public static void DontDestroyOnLoad(this Object target) {
#if UNITY_EDITOR // Skip Don't Destroy On Load when editor isn't playing so test runner passes.
        if (UnityEditor.EditorApplication.isPlaying)
#endif
            Object.DontDestroyOnLoad(target);
    }

    public static void Destroy(this GameObject go) {

        if(go != null) {
#if UNITY_EDITOR
            if (Application.isEditor) {
                GameObject.DestroyImmediate(go);
            }
            else
#endif
            {
                GameObject.Destroy(go);
            }
        }

    }


    /// <summary>
    /// Gets the GameObject's root Parent object.
    /// </summary>
    /// <param name="child">The GameObject we're trying to find the root parent for.</param>
    /// <returns>The Root parent GameObject.</returns>
    public static GameObject GetParentRoot(this GameObject child) {
        if (child.transform.parent == null) {
            return child;
        }
        else {
            return GetParentRoot(child.transform.parent.gameObject);
        }
    }
}