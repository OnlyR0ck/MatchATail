using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure;
using UnityEngine;

//Take base from Brackeys 

namespace Services
{
    public class AudioService : IAudioService
    {
        private AudioData[] backgroundMusicList;

        private readonly List<AudioData> sfxList = new List<AudioData>();


        private AudioData currentMusic;

        private AudioData prevMusic;
        private ICoroutineRunner coroutineRunner;
        private readonly Transform parent;

        public  AudioService(ICoroutineRunner coroutineRunner, Transform parent)
        {
            this.coroutineRunner = coroutineRunner;
            this.parent = parent;

            sfxList.AddRange(DataContainer.MotherCorrectActionData.AudioDatas);
            sfxList.AddRange(DataContainer.MotherIncorrectActionData.AudioDatas);
            sfxList.AddRange(DataContainer.WhereIsMyTailAudioData.AudioDatas);
            
            SetUpAudioArray(backgroundMusicList);
            SetUpAudioArray(sfxList);
            ClearCurrentPrevMusic();
        }


        private void SetUpAudioArray(IEnumerable<AudioData> array)
        {
            if (array == null)
            {
                return;
            }
            
            foreach (AudioData audioData in array)
            {
                GameObject tChild = new GameObject(audioData.m_name);
                tChild.transform.SetParent(parent);
                AudioSource tAudioSource = tChild.AddComponent<AudioSource>();

                audioData.m_object = tChild;
                audioData.m_audioSource = tAudioSource;

                audioData.m_audioSource.clip = audioData.m_audioClip;
                audioData.m_audioSource.volume = audioData.m_volume;
                audioData.m_audioSource.pitch = audioData.m_pitch;
                audioData.m_audioSource.loop = audioData.m_looping;
                audioData.m_audioSource.outputAudioMixerGroup = audioData.m_audioMixerGroup;
            }
        }

        private void ClearCurrentPrevMusic()
        {
            currentMusic = null;
            prevMusic = currentMusic;
        }

        public void PlayMusic(string name)
        {
            Debug.Log("Playing Music");
            AudioData tData = Array.Find(backgroundMusicList, bgm => bgm.m_name == name);
            if (tData == null)
            {
                Debug.LogError("Didn't find music");
            }
            else
            {
                prevMusic = currentMusic;
                currentMusic = tData;
                PlayNextMusicTrack();
            }
        }

        public void PlayMusic(int id)
        {
            if (id >= 0 && id < backgroundMusicList.Length)
            {
                Debug.Log("Playing Music");

                prevMusic = currentMusic;
                currentMusic = backgroundMusicList[id];

                PlayNextMusicTrack();
            }
            else
            {
                Debug.LogError("Didnt find music");
            }
        }

        private void PlayNextMusicTrack()
        {
            currentMusic.m_audioSource.Play();
            if (!currentMusic.m_fade && prevMusic?.m_audioSource != null)
            {
                prevMusic.m_audioSource.Stop();
            }
            if (currentMusic.m_fade)
            {
                coroutineRunner.StartCoroutine(FadeIn(currentMusic));
                if (prevMusic.m_audioSource != null)
                {
                    coroutineRunner.StartCoroutine(FadeOut(prevMusic));
                }
            }
        }

        public void PlaySFX(string name)
        {
            // AudioData tData = Array.Find(sfxList, sfx => sfx.m_name == name);
            AudioData audioClip = sfxList.Find(sfx => sfx.m_name == name);
            if (audioClip == null)
            {
                Debug.LogError("Didn't find sound");
            }
            else
            {
                audioClip.m_audioSource.Play();
            }
        }

        public void PlaySFX(int id)
        {
            if (id >= 0 && id < sfxList.Count)
            {
                Debug.Log("Playing sound");
                sfxList[id].m_audioSource.Play();
            }
            else
            {
                Debug.LogError("Didn't find sound");
            }
        }

        private IEnumerator FadeIn(AudioData audioData)
        {
            audioData.m_audioSource.volume = 0;
            float tVolume = audioData.m_audioSource.volume;

            while (audioData.m_audioSource.volume < audioData.m_volume)
            {
                tVolume += audioData.m_fadeInSpeed;
                audioData.m_audioSource.volume = tVolume;
                yield return new WaitForSeconds(0.1f);
            }
        }

        private IEnumerator FadeOut(AudioData audioData)
        {
            float tVolume = audioData.m_audioSource.volume;

            while (audioData.m_audioSource.volume > 0)
            {
                tVolume -= audioData.m_fadeOutSpeed;
                audioData.m_audioSource.volume = tVolume;
                yield return new WaitForSeconds(0.1f);
            }
            if (audioData.m_audioSource.volume == 0)
            {
                audioData.m_audioSource.Stop();
                audioData.m_audioSource.volume = audioData.m_volume;
            }
        }
    }
}