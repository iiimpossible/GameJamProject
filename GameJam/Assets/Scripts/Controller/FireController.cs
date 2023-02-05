using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool showFire = true;
    public List<SingleFire> fires = new List<SingleFire>();

    void Start()
    {
        foreach (var item in fires) {
            item.gameObject.SetActive(showFire);
        }
        ControllerManager.instance.RigisterFire(this);
        for (int i = 0; i < transform.childCount; i++) {
            var child = this.transform.GetChild(i);
            var fire = child.GetComponent<SingleFire>();
            if (fire != null) {
                fires.Add(fire);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void Switch()
    {
        showFire = !showFire;
        foreach (var item in fires) {
            item.gameObject.SetActive(showFire);
        }
    }
}
