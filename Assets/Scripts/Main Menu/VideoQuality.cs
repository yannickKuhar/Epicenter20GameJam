using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class VideoQuality : MonoBehaviour
{
    private void Awake()
    {
        const string QualitySettingsPath = "ProjectSettings\\QualitySettings.asset";
        SerializedObject graphicsManager = new SerializedObject(UnityEditor.AssetDatabase.LoadAllAssetsAtPath(QualitySettingsPath)[0]);        
    }

    public void QualityLow()
    {

    }

    public void QualityMed()
    {

    }

    public void QualityHigh()
    {

    }
}
