using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private static bool gameIsPause = false;

    [SerializeField]
    private GameObject pauseMenuUI;

    [SerializeField]
    private bool map;

    private Conductor conductor;


    private void Start()
    {
        conductor = new Conductor();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (gameIsPause)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }

    public void LoadMenu()
    {
        Resume();
        conductor = new Conductor();

        if (!map)
        {
            Saver.deleteLastPoint();
        }

        conductor.showScene((int)Scenes.MainMenu);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
