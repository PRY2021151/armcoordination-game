using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Entities;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.SceneManagement;
using System;
using EasyUI.Toast;

public class selectMusicAndPlayer : MonoBehaviour
{
    public gameInformation gameInfo;
    public Dropdown children;
    List<string> childrenOptions = new List<string>();
    JSONNode data;
    public Text title;

    public AudioSource audioSource;
    public AudioClip music_one;
    public AudioClip music_two;
    public AudioClip music_three;
    public AudioClip music_four;
    public AudioClip music_five;
    public AudioClip music_six;
    public AudioClip music_seven;
    public AudioClip music_eight;
    public AudioClip music_nine;
    public AudioClip music_ten;
    public AudioClip music_eleven;
    public AudioClip music_twelve;

    private void Awake()
    {
        gameInfo = FindObjectOfType<gameInformation>();
        audioSource = FindObjectOfType<AudioSource>();
    }

    public void listChildren() => StartCoroutine(listChildrenAPI());

    private IEnumerator listChildrenAPI() {
        child _child = new child();
        _child.relationship = gameInfo.email;
        string jsonUserSignUp = JsonUtility.ToJson(_child);

        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://armcoordination-api.azurewebsites.net/api/Child/child"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonUserSignUp);
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                data = JSON.Parse(webRequest.downloadHandler.text);
                for (int i = 0; i < data.Count; i++) {
                    childrenOptions.Add(data[i]["names"] + " " + data[i]["last_name"]);
                }
                
            }

            
            children.AddOptions(childrenOptions);
        }
    }

    void Start()
    {
        listChildren();
    }


    public void play_music_one() {
        audioSource.Stop();
        audioSource.clip = music_one;
        audioSource.Play();
   }
    public void play_music_two()
    {
        audioSource.Stop();
        audioSource.clip = music_two;
        audioSource.Play();
    }

    public void play_music_three()
    {
        audioSource.Stop();
        audioSource.clip = music_three;
        audioSource.Play();
    }

    public void play_music_four()
    {
        audioSource.Stop();
        audioSource.clip = music_four;
        audioSource.Play();
    }

    public void play_music_five()
    {
        audioSource.Stop();
        audioSource.clip = music_five;
        audioSource.Play();
    }

    public void play_music_six()
    {
        audioSource.Stop();
        audioSource.clip = music_six;
        audioSource.Play();
    }

    public void change_scene_login()
    {
        gameInfo.recordSceneInformationLogin("empty", "empty");
        SceneManager.LoadScene("login");
    }

    public void play_music_seven()
    {
        audioSource.Stop();
        audioSource.clip = music_seven;
        audioSource.Play();
    }

    public void play_music_eight()
    {
        audioSource.Stop();
        audioSource.clip = music_eight;
        audioSource.Play();
    }

    public void play_music_nine()
    {
        audioSource.Stop();
        audioSource.clip = music_nine;
        audioSource.Play();
    }

    public void play_music_ten()
    {
        audioSource.Stop();
        audioSource.clip = music_ten;
        audioSource.Play();
    }

    public void play_music_eleven()
    {
        audioSource.Stop();
        audioSource.clip = music_eleven;
        audioSource.Play();
    }

    public void play_music_twelve()
    {
        audioSource.Stop();
        audioSource.clip = music_twelve;
        audioSource.Play();
    }

    public void change_scene_rhythm_game()
    {
        if (audioSource.clip == null)
        {
            Toast.Show("Eligir una música", 2f, ToastColor.Red);
        }
        else {
            gameInfo.recordSceneInformationChildMusic(data[children.value]["id"], data[children.value]["names"], data[children.value]["last_name"], 0, audioSource.clip.name);
            audioSource.Stop();
            SceneManager.LoadScene("rhythm game");
        }


    }
}
