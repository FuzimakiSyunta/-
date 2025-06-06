using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    public GameObject moveTutorialPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMoveTutorial()
    {
        if (moveTutorialPanel != null)
        {
            moveTutorialPanel.SetActive(true);
        }
    }
}
