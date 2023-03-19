using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoresMenu : MonoBehaviour
{
    
    public TextMeshProUGUI dataSaved;
    void Start()
    {
        dataSaved.text = "\t Name \t Score\n";
        for (int i = 0; i < GameManager.Instance.scoresSaved.Count; i++)
        {
            dataSaved.text += $"\t {GameManager.Instance.namesSaved[i]} \t {GameManager.Instance.scoresSaved[i]}\n";
        }
    }
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
}
