using System.Collections.Generic;
using UnityEngine;

public class InstantiatePoolObject : MonoBehaviour
{
    [SerializeField]
    public GameObject _prefab;
    private List<GameObject> _pool = new List<GameObject>();

    private GameObject GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        var newObj = Instantiate(_prefab);
        _pool.Add(newObj);
        return newObj;
    }

    public void InstatiateObject(Transform target)
    {
        var obj = GetObject();
        obj.transform.SetPositionAndRotation(target.position, target.rotation);
        obj.SetActive(true);
    }
}
