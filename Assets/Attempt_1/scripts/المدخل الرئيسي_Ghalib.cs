// Unity C# code
using UnityEngine;
using System.Collections;

public class EntranceScene : MonoBehaviour
{
    public GameObject flickerLight;
    public GameObject bloodSplatter;
    public GameObject ghalibShadow;
    void Start()
    {
        // Spawn initial horror elements
        flickerLight.SetActive(true);
        flickerLight.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Fade");
        bloodSplatter.SetActive(false); // Enable after player interaction
        PlayAmbientSound("creaking_floorboards.wav");

        // Summon Ghalib after 30 seconds if not already present
        Invoke(nameof(SummonGhalib), 30f);
    }

    void SummonGhalib()
    {
        if (!ghalibShadow.activeInHierarchy)
        {
            Instantiate(ghalibShadow, transform.position + new Vector3(0, 0, -2), Quaternion.identity);
            ghalibShadow.SetActive(true);
        }
    }

    void PlayAmbientSound(string clipName)
    {
        AudioSource.PlayClipAtPoint(Resources.Load<AudioClip>(clipName), transform.position);
    }
}