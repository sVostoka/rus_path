using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Conductor : MonoBehaviour
{
    public Dictionary<string, int> scenes = new Dictionary<string, int>()
    {
        { "MainMenu", 0},
        { "Authors", 1},
        { "Map", 2},
        { "Fight", 3},
        { "GetCards", 4},
        { "GetBonus", 5},
        { "BossFight", 6},
        { "Rules", 7},
    };

    public void findScene(string sceneName)
    {
        try
        {
            int idScene = int.Parse(sceneName);
            showScene(idScene);
        }
        catch (Exception)
        {
            if (scenes.ContainsKey(sceneName))
                showScene(scenes[sceneName]);
            else
            {
                var button = EventSystem.current.currentSelectedGameObject;
                Debug.LogError($"У кнопки {button.name} указано неверное название сцены для перехода");
            }
        }
    }

    public void showScene(int idScene = 0)
    {
        SceneManager.LoadScene(idScene, LoadSceneMode.Single);
    }

    public void quitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}

enum Scenes
{
    MainMenu,
    Authors,
    Map,
    Fight,
    GetCards,
    GetBonus,
    BossFight,
    Rules
}
