using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Adafruit;

public class ResourceManager : PersistentSingleton<ResourceManager>
{
    // @formatter:off
    
    [Header("Plant List")] 
    public PlantListView PlantListView;
    public PlantListItemView PlantListItemView;
    
    [Header("Data")]
    public PlantDataController PlantDataController;
    
    public Sprite GetImportImage(string id)
    {
        if (string.IsNullOrEmpty(id))
            return null;

        var sprite = Resources.Load<Sprite>("Sprites/" + id);
        return sprite;
    }
}