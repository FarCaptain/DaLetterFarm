using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void JumpToNextLevel()
    {
        int idx = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(idx + 1);
    }
}
