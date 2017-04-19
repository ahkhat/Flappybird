using UnityEngine;
using System.Collections;


public class scene : MonoBehaviour {

    public bool crash;
    public GameObject BORU;
 
	void Start () {
        crash = false;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(crash){
            
            Invoke("pool", 3f);
            crash = false;
          
       }
	
	}
    void pool() {
        transform.position = transform.position+new Vector3(24,0,0);
        float degis = Random.Range(0f, 0.9f);
        Debug.Log(degis.ToString());
        BORU.transform.localPosition = new Vector3(0, degis, 0.15f);

       
    }
}
