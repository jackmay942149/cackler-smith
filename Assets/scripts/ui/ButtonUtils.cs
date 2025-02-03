using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUtils : MonoBehaviour
{
    bool loadingMainMenu = false;
    [SerializeField] GameObject[] buttonsToFadeIn;
    [SerializeField] GameObject[] textToFadeIn;
    [SerializeField] GameObject[] spritesToFadeIn; 

    [SerializeField] GameObject[] buttonsToFadeOut;
    [SerializeField] GameObject[] textToFadeOut;
    [SerializeField] GameObject[] spritesToFadeOut;

    [SerializeField] float sceneLoadTime = 1.0f;
    float sceneLoadingTime = 0.0f;

    AsyncOperation loadScene;

    private void Update()
    {
        if (loadingMainMenu)
        {
            sceneLoadingTime += Time.deltaTime;

            if (sceneLoadingTime > sceneLoadTime)
            { 
                loadingMainMenu = false;
                loadScene.allowSceneActivation = true;
                return;
            }

            float fadeInTransparency = sceneLoadingTime/sceneLoadTime;
            float fadeOutTransparency = 1 - fadeInTransparency;

            foreach (var button in buttonsToFadeIn)
            {
                button.GetComponent<Image>().color = new Color(1, 1, 1, fadeInTransparency);
            }

            foreach (var text in textToFadeIn)
            {
                text.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, fadeInTransparency);
            }

            foreach (var text in spritesToFadeIn)
            {
                text.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, fadeInTransparency);
            }

            foreach (var button in buttonsToFadeOut)
            {
                button.GetComponent<Image>().color = new Color(1, 1, 1, fadeOutTransparency);
            }

            foreach(var text in textToFadeOut)
            {
                text.GetComponent<TextMeshProUGUI>().color = new Color(1, 1, 1, fadeOutTransparency);
            }

            foreach (var text in spritesToFadeOut)
            {
                text.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, fadeOutTransparency);
            }
        }

    }

    public void LoadCampaign()
    {
        loadingMainMenu = true;
        loadScene = SceneManager.LoadSceneAsync("campaign");
        loadScene.allowSceneActivation = false;
    }
}
