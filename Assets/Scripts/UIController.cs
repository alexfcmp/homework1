using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LevelMaze
{
    public class UIController : MonoBehaviour
    {
        Text keyText;
        GameObject winText;

        void Start()
        {
            Player.onPlayerCollectKey += OnKeyCollected;
            WinController.onPlayerWin += OnPlayerWon;
        }

        void OnKeyCollected() => keyText.text = $"{Player.keys} keys left";

        void OnPlayerWon() => winText.SetActive(true);
    }
}
