using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Debug;

namespace LevelMaze
{
    public class KeyPanel : MonoBehaviour
    {
        public GameObject door;
        public static bool hasKeys;
        public static UnityAction onPlayerTouchedPanel;

        void OnCollisionEnter(Collision collision)
        {
            onPlayerTouchedPanel.Invoke();
            Log("touch2");
        }

        void OnCollisionStay(Collision collision)
        {
            if (hasKeys)
            {
                Destroy(door);
                Log("destroy door");
            }
        }
    }
}