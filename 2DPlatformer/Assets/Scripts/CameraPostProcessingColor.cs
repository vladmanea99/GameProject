using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraPostProcessingColor : MonoBehaviour
{
    PostProcessVolume postProcessVolume;
    public PostProcessProfile[] profiles;
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

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("1"))
        {
            poz = 0;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = new Vector3(0, 0);
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (Input.GetKeyDown("2"))
        {
            poz = 1;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = new Vector3(LevelDistance, 0);
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (Input.GetKeyDown("3"))
        {
            poz = 2;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = new Vector3(2 * LevelDistance, 0);
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (Input.GetKeyDown("4"))
        {
            poz = 3;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = new Vector3(3 * LevelDistance, 0);
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        if (Input.GetKeyDown("5"))
        {
            poz = 4;
            postProcessVolume.profile = profiles[poz % profiles.Length];
            Vector3 cameraFollowPosition = new Vector3(4 * LevelDistance, 0);
            cameraFollowPosition.z = transform.position.z;
            transform.position = cameraFollowPosition;
        }
        
    }
}
