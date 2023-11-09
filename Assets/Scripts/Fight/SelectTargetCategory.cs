using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTargetCategory : MonoBehaviour
{
    [SerializeField]
    public GameObject selectMenu;

    static bool visibility;

    // Start is called before the first frame update
    void Start()
    {
        visibility = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (visibility)
        {
            selectMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            selectMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public static void Hide()
    {
        visibility = false;
    }

    public static void Show()
    {
        visibility = true;
    }
}
