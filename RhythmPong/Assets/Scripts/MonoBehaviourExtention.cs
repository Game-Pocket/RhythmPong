using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{
    //< MonoBehaviour 확장함수를 작성한 파일
    static public class MonoBehaviourExtention
    {
        public static T GetComponentInChildren<T>(this Component mono, string childName) where T : Component
        {
            if (string.IsNullOrEmpty(childName) == true) return default(T);

            Transform child = mono.transform.Find(childName);

            if (child == null) return default(T);

            return child.GetComponent<T>();
        }
    }
}