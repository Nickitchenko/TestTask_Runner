/*
using UnityEngine;

public class DeleteAll : MonoBehaviour // Для билда 
{
    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
*/
///////////////////////////////////////////

using UnityEngine;
using UnityEditor;

public class DeleteAll :  EditorWindow // Для теста
{

    [MenuItem("DeleteAll/Delete all player prefs")]
    public static void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
