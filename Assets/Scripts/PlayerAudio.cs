using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public class PlayerAudio : MonoBehaviour
    {
        static AudioSource audioSource;
        public List<AudioClip> footSteps;
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            StartCoroutine(ChangeAudioClip());
            Player.AudioEvent += OnPlayerWalk;
        }

        IEnumerator ChangeAudioClip()
        {
            audioSource.clip = footSteps[Random.Range(0, footSteps.Count - 1)];

            yield return new WaitForSeconds(1f);
        }

        public static void OnPlayerWalk()
        {
            audioSource.Play();
            Player.AudioEvent -= OnPlayerWalk;
        }
    }
}
