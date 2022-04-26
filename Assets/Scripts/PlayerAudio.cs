using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelMaze
{
    public sealed class PlayerAudio : MonoBehaviour
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] List<AudioClip> footSteps;
        void Start()
        {
            StartCoroutine(ChangeAudioClip());
        }

        IEnumerator ChangeAudioClip()
        {
            audioSource.clip = footSteps[Random.Range(0, footSteps.Count - 1)];

            yield return new WaitForSeconds(0.7f);
        }
    }
}