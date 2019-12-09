using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    void Start()
    {
        StartCoroutine(RockinRollin());
    }

    IEnumerator RockinRollin()
    {
        while (true)
        {
            Instantiate(prefab, transform);
            yield return new WaitForSeconds(2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
