using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

// Create a new type of Settings Asset.
public class TokenageGameSettings : ScriptableObject
{
    public const string tokenageGameSettingsPath = "Assets/TokenageGameSettings.asset";

    [SerializeField]
    private int gameId;

    [SerializeField]
    private string gameName;

    [SerializeField]
    private string ERC20Contract;

#if UNITY_EDITOR

    internal static TokenageGameSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<TokenageGameSettings>(tokenageGameSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<TokenageGameSettings>();
            settings.gameId = 42;
            settings.gameName = "Tic Tac Toe";
            settings.ERC20Contract = "";
            AssetDatabase.CreateAsset(settings, tokenageGameSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
#endif

    public int ReturnGameID()
    {
        return gameId;
    }

    public string ReturnGameName()
    {
        return gameName;
    }

    public string ReturnERC20Contract()
    {
        return ERC20Contract;
    }
}

// Register a SettingsProvider using IMGUI for the drawing framework:
static class MyCustomSettingsIMGUIRegister
{
#if UNITY_EDITOR
    [SettingsProvider]
    public static SettingsProvider CreateTokenageGameSettingsProvider()
    {
        // First parameter is the path in the Settings window.
        // Second parameter is the scope of this setting: it only appears in the Project Settings window.
        var provider = new SettingsProvider("Project/TokenageGameIMGUISettings", SettingsScope.Project)
        {
            // By default the last token of the path is used as display name if no label is provided.
            label = "Tokenage",
            // Create the SettingsProvider and initialize its drawing (IMGUI) function in place:
            guiHandler = (searchContext) =>
            {
                var settings = TokenageGameSettings.GetSerializedSettings();
                EditorGUILayout.PropertyField(settings.FindProperty("gameId"), new GUIContent("Game ID"));
                EditorGUILayout.PropertyField(settings.FindProperty("gameName"), new GUIContent("Game Name"));
                EditorGUILayout.PropertyField(settings.FindProperty("ERC20Contract"), new GUIContent("ERC20 Contract"));
                settings.ApplyModifiedPropertiesWithoutUndo();
            },

            // Populate the search keywords to enable smart search filtering and label highlighting:
            keywords = new HashSet<string>(new[] { "Name", "Id", "Contract" })
        };

        return provider;
    }
#endif
}