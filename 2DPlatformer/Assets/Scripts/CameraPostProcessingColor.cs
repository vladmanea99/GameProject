using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPostProcessingColor : MonoBehaviour
{
    PostProcessVolume postProcessVolume;
    public PostProcessProfile[] profiles;

    float debugTime = 3f;
    float currentDebugTime = 0f;

    int poz = 0;
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        foreach (PostProcessProfile profile in profiles)
        {
            Debug.Log(profile.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (currentDebugTime > debugTime)
        {
            currentDebugTime = 0;
            poz++;
            postProcessVolume.profile = profiles[poz % profiles.Length];
        }

        currentDebugTime += Time.deltaTime;
    }
}
