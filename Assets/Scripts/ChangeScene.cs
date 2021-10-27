using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void change_scene_rhythm_game()
    {
        SceneManager.LoadScene("rhythm game");
    }

    public void change_scene_login()
    {
        SceneManager.LoadScene("login");
    }
}
