using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Vector3 scaleChange, positionChange;
    //Fresnel part
    public float FresnelPower = 0f;

    void Start ()
	{
		//scale part
		scaleChange = new Vector3(0.1f, 0.1f, 0.1f);
        positionChange = new Vector3(0.0f, 0.05f, 0.0f);
	}

    IEnumerator ScaleCoroutine()
    {
        this.transform.localScale += scaleChange;
		this.transform.position += positionChange;
        FresnelPower += 0.15f;
        GetComponent<Renderer>().material.SetFloat("_FresnelPower", FresnelPower);

        yield return new WaitForSeconds(1);
        this.transform.localScale += scaleChange;
		this.transform.position += positionChange;
        FresnelPower += 0.15f;
        GetComponent<Renderer>().material.SetFloat("_FresnelPower", FresnelPower);
        

        yield return new WaitForSeconds(1);
        this.transform.localScale += scaleChange;
		this.transform.position += positionChange;
        FresnelPower += 0.15f;
        GetComponent<Renderer>().material.SetFloat("_FresnelPower", FresnelPower);

        yield return new WaitForSeconds(1);
        this.transform.localScale += scaleChange;
		this.transform.position += positionChange;
        FresnelPower += 0.15f;
        GetComponent<Renderer>().material.SetFloat("_FresnelPower", FresnelPower);

        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other) 
	{
        StartCoroutine(ScaleCoroutine());
	}
}
