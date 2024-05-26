using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinqExample : MonoBehaviour
{
    
    void Start()
    {
        var urls = new List<string>() { "123","234"};
        urls.Where(url=>url.Length > 1).First().ToList().ForEach(url=>Debug.Log(url));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
