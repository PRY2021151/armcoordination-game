using Assets.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using EasyUI.Toast;
using UnityEngine.SceneManagement;

public class showCongratulations : MonoBehaviour
{
    [SerializeField]
    private Text name_player;

    public gameInformation gameInfo;

    private void Awake()
    {
        gameInfo = FindObjectOfType<gameInformation>();

        name_player.text = gameInfo.names + " " + gameInfo.lastName;
    }

    public void saveInformation() => StartCoroutine(saveInformationAPI());

    public IEnumerator saveInformationAPI() {

        session sessionInfo = new session();
        sessionInfo.score = gameInfo.score;
        sessionInfo.maximum_response = gameInfo.maximum_response;
        sessionInfo.minimum_response = gameInfo.minimum_response;
        sessionInfo.average_response = gameInfo.average_response;
        sessionInfo.hits_left_arm = gameInfo.hits_left_arm;
        sessionInfo.hits_right_arm = gameInfo.hits_right_arm;
        sessionInfo.accuracy_percentage = gameInfo.accuracy_percentage;
        sessionInfo.failures_right_arm = gameInfo.failures_right_arm;
        sessionInfo.failures_left_arm = gameInfo.failures_left_arm;
        sessionInfo.child_id = gameInfo.id;

        string jsonUserSignUp = JsonUtility.ToJson(sessionInfo);
        using (UnityWebRequest webRequest = new UnityWebRequest("https://armcoordination-api.azurewebsites.net/api/Session/session", "POST"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonUserSignUp);
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                //SceneManager.LoadScene("child music");
                Application.Quit();
            }
        }

    }


}
