using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public class Bonuses : MonoBehaviour
    {
        public List<BadBonus> badBonuses;
        public List<GoodBonus> goodBonuses;

        void Start()
        {
            ResetBonuses(true);
            ResetBonuses(false);
            GoodBonus.onGoodBonusTook += OnGoodBonusTook;
            BadBonus.onBadBonusTook += OnBadBonusTook;

            OnGoodBonusTook();
            OnBadBonusTook();
        }

        void ResetBonuses(bool isBadBonus)
        {
            if (isBadBonus)
            {
                foreach (var bonus in badBonuses)
                {
                    bonus.gameObject.SetActive(false);
                }
            } else
            {
                foreach (var bonus in goodBonuses)
                {
                    bonus.gameObject.SetActive(false);
                }
            }
        }

        void OnBadBonusTook()
        {
            ResetBonuses(true);
            badBonuses[Random.Range(0, badBonuses.Count-1)].gameObject.SetActive(true);
            //возможно повторение прошлого индекса
        }
        void OnGoodBonusTook()
        {
            ResetBonuses(false);
            goodBonuses[Random.Range(0, goodBonuses.Count-1)].gameObject.SetActive(true);
            //возможно повторение прошлого индекса
        }
    }
}