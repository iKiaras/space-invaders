using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetRefLoader : MonoBehaviour
{
    public static async Task CreateAsset<T>(AssetReference reference, List<T> completedObjects) 
        where T : ScriptableObject
    {
        completedObjects.Add( await reference.LoadAssetAsync<T>().ToUniTask());
    }
    
    public static async UniTask CreateAssetsAddToList<T>(List<AssetReference> references, List<T> completedObjects) 
        where T : ScriptableObject
    {
        foreach (AssetReference reference in references)
        {
            completedObjects.Add(await reference.LoadAssetAsync<T>().ToUniTask());
        }
    }
}
