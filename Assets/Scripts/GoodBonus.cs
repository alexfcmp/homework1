using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public sealed class GoodBonus : MonoBehaviour
    {
        internal static UnityAction onGoodBonusTook;

        void SpeedHigh()
        {
            Player.speed = Random.Range(8, 15);
        }
        void OnTriggerEnter(Collider other)
        {
            SpeedHigh();
            onGoodBonusTook.Invoke();
        }
    }
}