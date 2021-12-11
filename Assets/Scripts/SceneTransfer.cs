using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransfer : MonoBehaviour
{
    //move the object to the XR scene and then put it in the newscene
    //the game object has to be in the root of the original scene
    //when interacting with the object, the system automatically puts the object in the bottom
    // and puts it back after interaction
    public string toScene = "XR";

    //about the layers: we can not edit the editor to change the layers to different layer masks
    // all the inspector items have a typical way to make a custom version of it.
    public bool changeLayer = true;
    public int toLayer = 0; //default layer


    string previousScene;
    int previousLayer = 0;

    public void Transfer()
    {
        if (gameObject.scene.name == toScene) return;

        if (transform.parent != null)
        {
            //move object to root
            transform.SetParent(null);
        }

        Scene newScene = SceneManager.GetSceneByName(toScene);

        if (newScene.IsValid())
        {
            previousScene = gameObject.scene.name;
            previousLayer = gameObject.layer;
            SceneManager.MoveGameObjectToScene(gameObject, newScene);
            if (changeLayer) gameObject.layer = toLayer;
        }
    }


    public void Return()
    {
        if (previousScene == string.Empty) return;// never been to the previous scene
        Scene prevScene = SceneManager.GetSceneByName(previousScene);
        if (!prevScene.IsValid())
        {
            prevScene = SceneManager.GetActiveScene();
        }

        if (changeLayer) gameObject.layer = previousLayer;

        if (gameObject.scene.name == prevScene.name) return;//if we are already here!

        SceneManager.MoveGameObjectToScene(gameObject, prevScene);//put the gameobejct to the new scene
    }
}