using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Linq;

public static class SceneSelector
{
    [MenuItem("Scenes/OpenLobby")]

    static void OpenLobby()
    {
        Load("Lobby");
    }

    [MenuItem("Scenes/OpenBedroom")]

    static void OpenBedroom()
    {
        Load("Bedroom");
    }

    [MenuItem("Scenes/OpenBridge")]

    static void OpenBridge()
    {
        Load("Bridge");
    }

    [MenuItem("Scenes/OpenPrison")]

    static void OpenPrison()
    {
        Load("Prison");
    }


    static void Load(string scene)
    {
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo(); 

        Scene xrScene = EditorSceneManager.OpenScene("Assets/Scenes/XR.unity", OpenSceneMode.Single);
        Scene newScene = EditorSceneManager.OpenScene("Assets/Scenes/" + scene + ".unity", OpenSceneMode.Additive);
        XRSceneTransitionManager.PlaceXRRig(xrScene, newScene);
    } 

}
