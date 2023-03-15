using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : PersistentSingleton<ResourceManager>
{
    // @formatter:off
    
    [Header("Plant List")] 
    public PlantListview PlantListView;
    public PlantListItemView PlantListItemView;
}