using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    public GameObject Arrow_effect;

    AudioSource shoot_wav;

    public float speed = 20f;
    
    public int ccount;

    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }


    void Arrow_shoot()
    {

        shoot_wav = this.GetComponent<AudioSource>();
        shoot_wav.loop = false;
        shoot_wav.playOnAwake = false;

        if (shoot_wav.isPlaying == true) //재생중이면
        {
            shoot_wav.Stop();   //멈추고
        }
        shoot_wav.Play();

        GameObject star_particle = Instantiate(Arrow_effect, this.transform.position, Quaternion.identity);
        Destroy(star_particle, 1f);

    }

    private void OnTriggerEnter(Collider other)
    {
        ccount = Poong.collcount++;

        if (other.gameObject.tag == "Poong")
        {
            Arrow_shoot();
        }

        if (other.gameObject.tag == "Poong3")
        {
            Invoke("GetBackWorld_Clear", 2f);
        }
    }

    void GetBackWorld_Clear()
    {
        SceneManager.LoadScene("LoadingScene");
    }
}