using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public class PlayerAudio : MonoBehaviour
    {
        public AudioSource audioSource;
        public List<AudioClip> footSteps;
        void Start()
        {
            StartCoroutine(ChangeAudioClip());
            Player.AudioEvent += OnPlayerWalk;
        }

        IEnumerator ChangeAudioClip()
        {
            audioSource.clip = footSteps[Random.Range(0, footSteps.Count - 1)];

            yield return new WaitForSeconds(1f);
        }

        public void OnPlayerWalk() => audioSource.Play();
    }
}
