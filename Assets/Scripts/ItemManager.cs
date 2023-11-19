using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "ItemManager", menuName = "ItemManager")]
public class ItemManager : MonoBehaviour
{

    public Item[] itemPrefabs;
    //private List<Item> itemList;

    public void SpawnItemAt(Vector3 position, Quaternion rotation)
    {
        Item itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
        //Item itemPrefab = itemPrefabs[0];
        Instantiate(itemPrefab, position, rotation);
    }

}
