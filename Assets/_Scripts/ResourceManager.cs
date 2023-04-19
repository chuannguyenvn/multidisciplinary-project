using System;
using System.Collections;
using System.Collections.Generic;
using Communications.Requests;
using Communications.Responses;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class ResourceManager : PersistentSingleton<ResourceManager>
{
    // @formatter:off
    
    //[Header("Data")]
    //public PlantDataController PlantDataController;

    public string bearerKey = "";
    public bool IsCorrect = false;
    
    public IEnumerator RequestGetAllDataPlants()
    {
        yield return RequestCreator.SendRequest<GetPlantResponse>(
            endpoint: "dadn.azurewebsites.net/plantmanagement/get",
            requestType: RequestCreator.Type.GET,
            bearerKey: bearerKey,
            callback: (success, response) =>
            {
                if (success)
                {
                    foreach (var plantData in response.PlantInformations)
                    {
                        //Debug.LogError(string.Format("Id: {0}, name: {1}", plantData.Id, plantData.Name));
                        //PlantManager.Instance.ListPlantName.Add(plantData.Id.ToString());
                        PlantDataController dataController = new PlantDataController();
                        dataController.Init(plantData.Id, plantData.Name, plantData.CreatedDate, plantData.RecognizerCode);
                        PlantManager.Instance.DctPlantData.Add(plantData.Id, dataController);
                    }
                }
                else
                {
                    Debug.LogError("failed to get all plants data");
                }
            });
    }
    public IEnumerator RequestLogin(string username, string password)
    {
        yield return RequestCreator.SendRequest<AuthenticationResponse>(
            endpoint: "dadn.azurewebsites.net/authentication/login",
            requestType: RequestCreator.Type.POST,
            bearerKey: "",
            objectToSend: new AuthenticationRequest() { Username = "Chuan", Password = "chuan123" },
            callback: (success, response) =>
            {
                if (success)
                {
                    bearerKey = response.Token;
                    PlayerPrefs.SetString(Define.BearerKey, bearerKey);
                    IsCorrect = true;
                    Debug.Log("Login successfully with bearer key: " + bearerKey);
                    RequestGetAllDataPlants();
                    SceneManager.Instance.ChangeScene(Define.SceneName.Main.ToString(), null);
                }
                else
                {
                    Debug.Log("Login failed.");
                }
            });
    }

    public IEnumerator RequestAddNewPlant(string name)
    {
        yield return RequestCreator.SendRequest(
            endpoint: "dadn.azurewebsites.net/plantmanagement/add",
            requestType: RequestCreator.Type.POST,
            bearerKey: bearerKey,
            objectToSend: new AddPlantRequest() { Name = name, Photo = "photo" },
            callback: success =>
            {
                if (success) Debug.Log("Added a new plant.");
                else Debug.Log("Adding plant failed.");
            });
    }
    public IEnumerator RequestGetLatestData()
    {
        yield return RequestCreator.SendRequest<PlantDataResponse>(
            endpoint: "dadn.azurewebsites.net/plantdata/1/latest",
            requestType: RequestCreator.Type.GET,
            bearerKey: bearerKey,
            callback: (success, response) =>
            {
                if (success)
                {
                    foreach (var point in response.PlantDataPoints)
                    {
                        Debug.Log(point.Timestamp + ": " + point.LightValue);
                    }
                }
                else
                {
                    Debug.Log("Failed to get plant's data.");
                }
            });
    }
    public Sprite GetImportImage(string id)
    {
        if (string.IsNullOrEmpty(id))
            return null;

        var sprite = Resources.Load<Sprite>("Sprites/" + id);
        return sprite;
    }

    public List<string> GetAllGalleryImagePaths()
    {
        List<string> results = new List<string>();
        HashSet<string> allowedExtesions = new HashSet<string>() { ".png", ".jpg", ".jpeg" };

        try
        {
            AndroidJavaClass mediaClass = new AndroidJavaClass("android.provider.MediaStore$Images$Media");

            // Set the tags for the data we want about each image.  This should really be done by calling; 
            //string dataTag = mediaClass.GetStatic<string>("DATA");
            // but I couldn't get that to work...

            const string dataTag = "_data";

            string[] projection = new string[] { dataTag };
            AndroidJavaClass player = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = player.GetStatic<AndroidJavaObject>("currentActivity");

            string[] urisToSearch = new string[] { "EXTERNAL_CONTENT_URI", "INTERNAL_CONTENT_URI" };
            foreach (string uriToSearch in urisToSearch)
            {
                AndroidJavaObject externalUri = mediaClass.GetStatic<AndroidJavaObject>(uriToSearch);
                AndroidJavaObject finder = currentActivity.Call<AndroidJavaObject>("managedQuery", externalUri, projection, null, null, null);
                bool foundOne = finder.Call<bool>("moveToFirst");
                while (foundOne)
                {
                    int dataIndex = finder.Call<int>("getColumnIndex", dataTag);
                    string data = finder.Call<string>("getString", dataIndex);
                    if (allowedExtesions.Contains(Path.GetExtension(data).ToLower()))
                    {
                        string path = @"file:///" + data;
                        results.Add(path);
                    }

                    foundOne = finder.Call<bool>("moveToNext");
                }
            }
        }
        catch (System.Exception e)
        {
            // do something with error...
            Debug.LogError("loi lay anh");
        }

        return results;
    }
}