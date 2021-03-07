using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
public class UserAPI : MonoBehaviour
{
    public static IEnumerator UpdateName(long id, string name, System.Action<string> callback)
    {
        var dto = new UpdateNameDto(id, name);
        var serialized = JsonConvert.SerializeObject(dto);
        using (var www = UnityWebRequest.Post("http://127.0.0.1:8080/api/users/name", serialized))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(serialized));

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    
                    callback(result);
                }
                else
                {
                    //handle the problem
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }

    public static IEnumerator UpdateScore(long id, int score, System.Action<string> callback)
    {
        var dto = new UpdateScoreDto(id, score);
        var serialized = JsonConvert.SerializeObject(dto);
        using (var www = UnityWebRequest.Post("http://127.0.0.1:8080/api/users/score", serialized))
        {
            www.SetRequestHeader("content-type", "application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(serialized));

            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    callback(result);
                }
                else
                {
                    Debug.Log("Error! data couldn't get.");
                }
            }
        }
    }

    public static IEnumerator Create(System.Action<string> resolve, System.Action<string> reject)
    {
        using(var www = UnityWebRequest.Get("http://127.0.0.1:8080/api/users/new"))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                reject(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    var result = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);

                    resolve(result);
                }
                else
                {
                    reject("Error!");
                }
            }
        }
    }
}
