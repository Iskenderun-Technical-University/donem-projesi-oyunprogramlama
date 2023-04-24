using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keles : MonoBehaviour
{
    public bool atesEdebilirMi;
    float iceridenAtesEtmeSikligi;
    public float disaridanAtesEtmeSikligi;
    public float menzil;
    public Camera benimCam;
    public AudioSource AtesSesi;
    public ParticleSystem AtesEfekt;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && atesEdebilirMi && Time.time > iceridenAtesEtmeSikligi)
        {
            AtesEt();
            iceridenAtesEtmeSikligi = Time.time + disaridanAtesEtmeSikligi;
        }
    }
    void AtesEt()
    {
        AtesSesi.Play();
        AtesEfekt.Play();

        RaycastHit hit;

        if (Physics.Raycast(benimCam.transform.position,benimCam.transform.forward,out hit,menzil))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
