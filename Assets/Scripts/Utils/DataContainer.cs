using System.Collections.Generic;
using ScriptableObjects.Audio;
using ScriptableObjects.Menu;
using Sirenix.OdinInspector;

public static class DataContainer
{
    #region Fields

    private static readonly Dictionary<int, UnityEngine.Object> dataPool = new Dictionary<int, UnityEngine.Object>();

    #endregion



    #region Properties

    public static AnimalItemsSequence AnimalItemsSequence =>
        GetData<AnimalItemsSequence>("Data/Animals/Data_AnimalItems");


    public static AudioClipsData WhereIsMyTailAudioData =>
        GetData<AudioClipsData>("Data/Audio/Data_AnimalsWhereIsMyTail");


    public static AudioClipsData MotherIncorrectActionData =>
        GetData<AudioClipsData>("Data/Audio/Data_MotherIncorrectAction");


    public static AudioClipsData MotherCorrectActionData =>
        GetData<AudioClipsData>("Data/Audio/Data_MotherCorrectAction");

    #endregion



    #region Private methods

    private static TDataType GetData<TDataType>(string path) where TDataType : SerializedScriptableObject
    {
        int key = path.GetHashCode();

        if (!dataPool.ContainsKey(key))
        {
            TDataType data = UnityEngine.Resources.Load<TDataType>(path);
            dataPool.Add(key, data);
            return data;
        }

        return dataPool[key] as TDataType;
    }

    #endregion
}