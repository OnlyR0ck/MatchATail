using System.Collections.Generic;
using ScriptableObjects.Menu;
using Sirenix.OdinInspector;

public static class DataContainer
{
    #region Fields

    private static Dictionary<System.Type, UnityEngine.Object> dataPool = new Dictionary<System.Type, UnityEngine.Object>();

    #endregion



    #region Properties

    public static MenuIconsSequence MenuIconsSequence =>
        GetData<MenuIconsSequence>("Data/Menu/Data_MenuItemsSequence");

    #endregion



    #region Private methods

    private static TDataType GetData<TDataType>(string path) where TDataType : SerializedScriptableObject
    {
        System.Type type = typeof(TDataType);

        if (!dataPool.ContainsKey(type))
        {
            TDataType data = UnityEngine.Resources.Load<TDataType>(path);
            dataPool.Add(type, data);
            return data;
        }

        return dataPool[type] as TDataType;
    }

    #endregion
}