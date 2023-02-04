using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    #region Custom Scene Switch Functions
    public void LoadMenuScene()
    {
        SceneChanger.instance.LoadMenuScene();
    }
    public void LoadHowToPlayScene()
    {
        SceneChanger.instance.LoadHowToPlayScene();
    }
    public void LoadCreditsScene()
    {
        SceneChanger.instance.LoadCreditsScene();
    }
    public void LoadGameScene()
    {
        SceneChanger.instance.LoadGameScene();
    }
    public void LoadOpeningCinematicScene()
    {
        SceneChanger.instance.LoadOpeningCinematicScene();
    }
    public void LoadStartTownScene()
    {
        SceneChanger.instance.LoadStartTownScene();
    }
    public void LoadShovelSnowScene()
    {
        SceneChanger.instance.LoadShovelSnowScene();
    }
    public void LoadCampfireScene()
    {
        SceneChanger.instance.LoadCampfireScene();
    }
    public void LoadCarryWaterScene()
    {
        SceneChanger.instance.LoadCarryWaterScene();
    }
    public void LoadFinishTownScene()
    {
        SceneChanger.instance.LoadFinishTownScene();
    }
    #endregion
}
