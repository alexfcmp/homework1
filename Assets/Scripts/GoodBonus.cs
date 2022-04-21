using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LevelMaze
{
    public class GoodBonus : MonoBehaviour
    {
        public static UnityAction onGoodBonusTook;

        void SpeedHigh()
        {
            Player.speed = Random.Range(11, 20);
        }
        void OnTriggerEnter(Collider other)
        {
            SpeedHigh();
            onGoodBonusTook.Invoke();
        }
    }
}