using Assets.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasyUI.Toast;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class loginValidation : MonoBehaviour
{
    [SerializeField]
    private InputField emailUI;
    [SerializeField]
    private InputField passwordUI;

    public gameInformation gameInfo;

    private void Start()
    {
        gameInfo = FindObjectOfType<gameInformation>();

        if (gameInfo.email != "empty" && gameInfo.password != "empty") {
            SceneManager.LoadScene("child music");
        }
    }

    public void loginUser() => StartCoroutine(loginUserAPI());

    private IEnumerator showMessageToast(bool successful, string message, string email, string password)
    {
        if (successful)
        {
            Toast.Show(message, 2f, ToastColor.Green);
        }
        else
        {
            Toast.Show(message, 2f, ToastColor.Red);
        }

        yield return new WaitForSeconds(2f);

        if (successful) {
            gameInfo.recordSceneInformationLogin(email, password);
            SceneManager.LoadScene("child music");
        }

    }

    private IEnumerator loginUserAPI()
    {
        AspNetUsers user = new AspNetUsers();
        user.email = emailUI.text;
        user.password = passwordUI.text;
        string jsonUserSignUp = JsonUtility.ToJson(user);

        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://armcoordination-api.azurewebsites.net/api/AspNetUsers/login"))
        {
            byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(jsonUserSignUp);
            webRequest.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
            webRequest.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {

                StartCoroutine(showMessageToast(true, "inicio de sesión exitoso",user.email, user.password));

            }
            else
            {
                StartCoroutine(showMessageToast(false, "inicio de sesión fallido", user.email, user.password));
            }
        }

    }
}
