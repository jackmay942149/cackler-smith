using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUtils : MonoBehaviour
{
    bool loading = false;
    [SerializeField] GameObject fadeOutObj;
    MeshRenderer mr;

    float startLoadingTime = 0.0f;
    bool starting = true;

    [SerializeField] float sceneLoadTime = 1.0f;
    float sceneLoadingTime = 0.0f;

    AsyncOperation loadScene;

    private void Start()
    {
        mr = fadeOutObj.GetComponent<MeshRenderer>();
    }



    private void Update()
    {
        if (loading)
        {
            sceneLoadingTime += Time.deltaTime;

            if (sceneLoadingTime > sceneLoadTime)
            {
                loading = false;
                loadScene.allowSceneActivation = true;
                return;
            }

            float fadeOutTransparency = 1 - Mathf.Pow(sceneLoadingTime/ sceneLoadTime, 0.5f);
            Color fadeOutColour = new Color(1.0f, 1.0f, 1.0f, fadeOutTransparency);
            mr.material.SetColor("_MainColor", fadeOutColour);
        }

        if (starting)
        {
            startLoadingTime += Time.deltaTime;

            float fadeInTransparency = Mathf.Pow(startLoadingTime / sceneLoadTime, 2f);
            Color fadeInColour = new Color(1.0f, 1.0f, 1.0f, fadeInTransparency);
            mr.material.SetColor("_MainColor", fadeInColour);

            if (startLoadingTime > sceneLoadTime)
            {
                starting = false;
                return;
            }

            
        }

    }

    public void LoadCampaign()
    {
        LoadLevel("campaign");
    }

    public void LoadMainMenu()
    {
        LoadLevel("main-menu");
    }

    public void LoadCharSelect()
    {
        LoadLevel("char-select");
    }

    public void LoadSettings()
    {
        LoadLevel("settings");
    }

    public void AppQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

    private void LoadLevel(string levelName)
    {
        if (loading) return;
        loading = true;
        loadScene = SceneManager.LoadSceneAsync(levelName);
        loadScene.allowSceneActivation = false;
    }
}
