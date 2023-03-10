using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    [SerializeField] string menuSceneName;
    [SerializeField] string howToPlaySceneName;
    [SerializeField] string creditsSceneName;
    [SerializeField] string gameSceneName;
    [SerializeField] string startTownSceneName;
    [SerializeField] string shovelSnowSceneName;
    [SerializeField] string campfireSceneName;
    [SerializeField] string carryWaterSceneName;
    [SerializeField] string finalTownSceneName;
    [SerializeField] string openingCinematicScene;

    private void Awake()
    {
        if (!instance) instance = this;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }
    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene(howToPlaySceneName);
    }
    public void LoadCreditsScene()
    {
        StartCoroutine(Credits());
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadStartTownScene()
    {
        SceneManager.LoadScene(startTownSceneName);
    }
    public void LoadShovelSnowScene()
    {
        SceneManager.LoadScene(shovelSnowSceneName);
    }
    public void LoadCampfireScene()
    {
        SceneManager.LoadScene(campfireSceneName);
    }
    public void LoadCarryWaterScene()
    {
        SceneManager.LoadScene(carryWaterSceneName);
    }
    public void LoadFinishTownScene()
    {
        SceneManager.LoadScene(finalTownSceneName);
    }
    public void LoadOpeningCinematicScene()
    {
        SceneManager.LoadScene(openingCinematicScene);
    }
    public void LoadTestBossArena()
    {
        SceneManager.LoadScene("Test Boss Arena");
    }
    public void LoadEndingCinematicScene()
    {
        StartCoroutine(EndGame());
    }
    IEnumerator EndGame()
    {
        FaderScript.instance.FadeIn();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Ending Cinematic Scene");
        yield return new WaitForSeconds(1f);
        FaderScript.instance.FadeOut(0.5f);
    }
    IEnumerator Credits()
    {
        FaderScript.instance.FadeIn(1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(creditsSceneName);
        yield return new WaitForSeconds(1f);
        FaderScript.instance.FadeOut(0.5f);
    }
}
