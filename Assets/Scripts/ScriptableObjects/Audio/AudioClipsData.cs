using Sirenix.OdinInspector;
using UnityEngine;

namespace ScriptableObjects.Audio
{
    [CreateAssetMenu(fileName = "Data_AudioClips", menuName = "Data/Audio/Audio Data")]
    public class AudioClipsData : SerializedScriptableObject
    {
        [SerializeField] private AudioData[] audioDatas;

        public AudioData[] AudioDatas => audioDatas;
    }
}
