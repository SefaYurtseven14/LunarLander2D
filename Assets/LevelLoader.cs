using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

    public int stageNumber;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Load());
    }
    IEnumerator Load()
    {
        yield return new WaitForSeconds(3);
        if (stageNumber == 1)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (stageNumber == 2)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (stageNumber == 3)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if (stageNumber == 4)
        {
            SceneManager.LoadScene("Stage4");
        }
    }
}
