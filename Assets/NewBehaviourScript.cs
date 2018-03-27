using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;

public class NewBehaviourScript : MonoBehaviour {
    //Call when loaded script
    string timeString = "hello";
    void Awake()
    {
        Debug.Log("Awake");
    }
    // Use this for initialization
    void Start ()
    {
        Debug.Log("Start");
    }
	
	// Update is called once per frame
	
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 180, 150), "Benchmark");
        
        if (GUI.Button(new Rect(20, 40, 100, 20), "BENCHMARK"))
        {
            SHA512Managed hashstring = new SHA512Managed();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (long i=0;i< 65536; i++)
            {
                System.Random rnd = new System.Random();
                string randomString = rnd.Next(32768, 1048576).ToString();
                byte[] bytes = Encoding.UTF8.GetBytes(randomString);
                var hash = hashstring.ComputeHash(bytes);
            }
            watch.Stop();
            timeString = watch.ElapsedMilliseconds.ToString();
            
            Debug.Log(timeString);
        }
        GUI.TextField(new Rect(20, 70, 100, 30), timeString);
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }
}
