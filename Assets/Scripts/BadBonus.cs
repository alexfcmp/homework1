using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public sealed class BadBonus : MonoBehaviour
{
        internal static UnityAction onBadBonusTook;

        void SpeedLow()
        {
            Player.speed = Random.Range(1, 3);
        }
        void OnTriggerEnter(Collider other)
        {
            SpeedLow();
            onBadBonusTook.Invoke();
        }
    }
}