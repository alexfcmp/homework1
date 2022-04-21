using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public class BadBonus : MonoBehaviour
{
        public static UnityAction onBadBonusTook;

        void SpeedLow()
        {
            Player.speed = Random.Range(1, 5);
        }
        void OnTriggerEnter(Collider other)
        {
            SpeedLow();
            onBadBonusTook.Invoke();
        }
    }
}