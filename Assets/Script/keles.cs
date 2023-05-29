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

    public ParticleSystem Mermi›zi;
    public ParticleSystem KanEfekti;

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

        if (Physics.Raycast(benimCam.transform.position, benimCam.transform.forward, out hit, menzil))
        {

            if (hit.transform.gameObject.CompareTag("Dusman"))
            {
                Instantiate(KanEfekti, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else if (hit.transform.gameObject.CompareTag("DevrilebilirObje"))
            {
                Rigidbody rg = hit.transform.gameObject.GetComponent<Rigidbody>();
                rg.AddForce(-hit.normal * 50f);
                Instantiate(Mermi›zi, hit.point, Quaternion.LookRotation(hit.normal));
            }
            else
            {
                Instantiate(Mermi›zi, hit.point, Quaternion.LookRotation(hit.normal));
            }

        }

    }
}
