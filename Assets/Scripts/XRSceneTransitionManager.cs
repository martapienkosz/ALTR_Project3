using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor.SceneManagement;
using System.Linq;



[DisallowMultipleComponent]
public class XRSceneTransitionManager : MonoBehaviour
{
    public static XRSceneTransitionManager Instance;

    public Material transitionMaterial;
    public float transitionSpeed = 0.0f;


    public bool isLoading { get; private set; } = false;

    public string initialScene;

    Scene xrScene;
    Scene currentScene;
    float currentTransitionAmount = 0.0f;

    // Start is called before the first frame update
    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Detected wrong XRSceneTransitionManager. Deleting It.");
            Destroy(this.gameObject);
            return;
        }

        xrScene = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += OnNewSceneAdded;

        if (!Application.isEditor)
        {
            TransitionTo(initialScene);
        }
    }

    public void TransitionTo(string scene)
    {
        if (!isLoading)
        {
            StartCoroutine(Load(scene));

        }
    }

    void OnNewSceneAdded(Scene newScene, LoadSceneMode mode)
    {
        if (newScene != xrScene)
        {
            currentScene = newScene;
            SceneManager.SetActiveScene(currentScene);
            PlaceXRRig(xrScene, currentScene);
        }
    }


    IEnumerator Load(string scene)
    {
        isLoading = true;
        yield return StartCoroutine(Fade(1.0f));
        yield return StartCoroutine(UnLoadCurrentScene());

        yield return StartCoroutine(LoadNewScene(scene));
        yield return StartCoroutine(Fade(0.0f));
        isLoading = false;
    }

    IEnumerator UnLoadCurrentScene()
    {
        if (currentScene.IsValid())
        {
            AsyncOperation unload = SceneManager.UnloadSceneAsync(currentScene);
            while (!unload.isDone)
            {
                yield return null;
            }
        }
    }

    IEnumerator LoadNewScene(string scene)
    {
        AsyncOperation load = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        while (!load.isDone)
        {
            yield return null;
        }

    }


    static public void PlaceXRRig(Scene xrScene, Scene newScene)
    {
        GameObject[] xrObjects = xrScene.GetRootGameObjects();
        GameObject[] newSceneObjects = newScene.GetRootGameObjects();

        GameObject xrRig = xrObjects.First((obj) => { return obj.CompareTag("XRRig"); });
        GameObject xrRigOrigin = newSceneObjects.First((obj) => { return obj.CompareTag("XRRigOrigin"); });


        if (xrRig && xrRigOrigin)
        {
            xrRig.transform.position = xrRigOrigin.transform.position;
            xrRig.transform.rotation = xrRigOrigin.transform.rotation;

        }
    }

    //call this line from any script to fade the screen to black
    //StartCoroutine(XRSceneTransitionManager.Instance.Fade(1.0f));

    //
    public IEnumerator Fade(float target)
    {

        while (!Mathf.Approximately(currentTransitionAmount, target))
        {
            currentTransitionAmount = Mathf.MoveTowards(currentTransitionAmount, target, transitionSpeed * Time.deltaTime);
            transitionMaterial.SetFloat("_FadeAmount", currentTransitionAmount);
             yield return null;
        }
        transitionMaterial.SetFloat("_FadeAmount", target);
    }
}

