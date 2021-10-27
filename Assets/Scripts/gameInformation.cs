using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameInformation : MonoBehaviour
{
    // scene login
    public string email = "empty";
    public string password = "empty";

    // scene child music
    public int id = 0;
    public string names = "";
    public string lastName = "";
    public int indexMusic = 0;
    public string nameMusic = "";

    // scene rhythm game
    public int score = 0;
    public int maximum_response = 0;
    public int minimum_response = 0;
    public float average_response = 0f;
    public int hits_left_arm = 0;
    public int hits_right_arm = 0;
    public float accuracy_percentage = 0f;
    public int failures_right_arm = 0;
    public int failures_left_arm = 0;

    public void recordSceneInformationLogin(string _email, string _password)
    {
        email = _email;
        password = _password;
    }

    public void recordSceneInformationChildMusic(int _id, string _names, string _lastName, int _indexMusic, string _nameMusic)
    {
        id = _id;
        names = _names;
        lastName = _lastName;
        indexMusic = _indexMusic;
        nameMusic = _nameMusic;
    }

    public void recordSceneInformationRhythmGame(int _score, int _maximum_response, int _minimum_response, float _average_response, int _hits_left_arm, int _hits_right_arm, float _accuracy_percentage, int _failures_right_arm, int _failures_left_arm)
    {
        score = _score;
        maximum_response = _maximum_response;
        minimum_response = _minimum_response;
        average_response = _average_response;
        hits_left_arm = _hits_left_arm;
        hits_right_arm = _hits_right_arm;
        accuracy_percentage = _accuracy_percentage;
        failures_right_arm = _failures_right_arm;
        failures_left_arm = _failures_left_arm;
    }

    private void Awake()
    {
        loadInformation();
    }

    private void OnDestroy()
    {
        saveInformation();
    }

    private void saveInformation()
    {
        PlayerPrefs.SetString("email", email);
        PlayerPrefs.SetString("password", password);

        PlayerPrefs.SetInt("id", id);
        PlayerPrefs.SetString("names", names);
        PlayerPrefs.SetString("lastName", lastName);
        PlayerPrefs.SetInt("indexMusic", indexMusic);
        PlayerPrefs.SetString("nameMusic", nameMusic);

        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("maximum_response", maximum_response);
        PlayerPrefs.SetInt("minimum_response", minimum_response);
        PlayerPrefs.SetFloat("average_response", average_response);
        PlayerPrefs.SetInt("hits_left_arm", hits_left_arm);
        PlayerPrefs.SetInt("hits_right_arm", hits_right_arm);
        PlayerPrefs.SetFloat("accuracy_percentage", accuracy_percentage);
        PlayerPrefs.SetInt("failures_right_arm", failures_right_arm);
        PlayerPrefs.SetInt("failures_left_arm", failures_left_arm);
    }

    private void loadInformation()
    {
        email= PlayerPrefs.GetString("email", "empty");
        password = PlayerPrefs.GetString("password", "empty");

        id = PlayerPrefs.GetInt("id", 0);
        names = PlayerPrefs.GetString("names", "");
        lastName = PlayerPrefs.GetString("lastName", "");
        indexMusic = PlayerPrefs.GetInt("indexMusic", 0);
        nameMusic = PlayerPrefs.GetString("nameMusic", "");

        score = PlayerPrefs.GetInt("score", 0);
        maximum_response = PlayerPrefs.GetInt("maximum_response", 0);
        minimum_response = PlayerPrefs.GetInt("minimum_response", 0);
        average_response = PlayerPrefs.GetFloat("average_response", 0f);
        hits_left_arm = PlayerPrefs.GetInt("hits_left_arm", 0);
        hits_right_arm = PlayerPrefs.GetInt("hits_right_arm", 0);
        accuracy_percentage = PlayerPrefs.GetFloat("accuracy_percentage", 0f);
        failures_right_arm = PlayerPrefs.GetInt("failures_right_arm", 0);
        failures_left_arm = PlayerPrefs.GetInt("failures_left_arm", 0);
    }
}
