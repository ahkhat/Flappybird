using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bird : MonoBehaviour {
    public float hiz;
    public float jump;
    public int puan;
    public AudioClip ölme;
    public AudioClip hit;
    public GameObject canvas;
    public Text rekor;
    public Text toplam;




	// Use this for initialization
	void Start () {
        canvas.SetActive(false);
        puan = 0;
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * hiz * Time.deltaTime);
        if (Input.touchCount == 1)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * jump);
        }
	
	}
    void OnTriggerEnter2D(Collider2D carp)
    {
        if (carp.gameObject.tag == "tetik")
        {
           carp.gameObject.transform.parent.root.gameObject.GetComponent<scene>().crash = true;
            Debug.Log(carp.gameObject.transform.parent.gameObject.transform.parent.gameObject.name);
            puan++;
            GetComponent<AudioSource>().PlayOneShot(hit);
        }
    }
    void OnCollisionEnter2D(Collision2D carp)
    {
        if (carp.gameObject.tag == "engel")
        {
            OyunSonu();

        }
    }
    void OyunSonu()
    {
        Time.timeScale = 0;
        GetComponent<AudioSource>().PlayOneShot(ölme);
        canvas.SetActive(true);

        if (puan > PlayerPrefs.GetInt("Rekor"))
        {
            PlayerPrefs.SetInt("Rekor", puan);
        }

        toplam.text = puan.ToString();
        rekor.text = PlayerPrefs.GetInt("Rekor").ToString();

    }
    public void Again()
    {
        SceneManager.LoadScene("FlapyBird");
    }
}
