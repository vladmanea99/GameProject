using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPostProcessingColor : MonoBehaviour
{
    PostProcessVolume postProcessVolume;
    public PostProcessProfile[] profiles;
    [SerializeField] Transform target;
    int poz = 0;
    public float LevelDistance = 39.08f; 
    // Start is called before the first frame update
    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        foreach (PostProcessProfile profile in profiles)
        {
            Debug.Log(profile.name);
        }
    }

    public void moveToDimension(string dimensionNumber, Vector3 positionForOffset)
    {
        Vector3 offset = positionForOffset - transform.position;
        Debug.Log(offset);
        if (dimensionNumber == "1")
        {
            poz = 0;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = target.position + offset;
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (dimensionNumber == "2")
        {
            poz = 1;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = target.position + offset;
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (dimensionNumber == "3")
        {
            poz = 2;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = target.position + offset;
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (dimensionNumber == "4")
        {
            poz = 3;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = target.position + offset;
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (dimensionNumber == "5")
        {
            poz = 4;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = target.position + offset;
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
    }

}
