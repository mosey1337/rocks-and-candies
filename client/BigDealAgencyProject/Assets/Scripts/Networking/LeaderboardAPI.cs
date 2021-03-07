using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class LeaderboardAPI : MonoBehaviour
{
    public static IEnumerator Get(System.Action<string> callback) 
    {
        using (var www = UnityWebRequest.Get("http://127.0.0.1:8080/api/leaderboard"))
        {
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
            }
        }
    }
}
