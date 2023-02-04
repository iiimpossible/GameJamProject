using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    [SerializeField]
    public List<SpecialElement> elements = new List<SpecialElement>();
    [SerializeField]
    private ActorController actor;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Rigister(SpecialElement element)
    {
        this.elements.Add(element);
    }

    public void RigisterActor(ActorController actor)
    {
        this.actor = actor;
    }

    public void EnterHack(SpecialElement element)
    {
        actor.OnIdle();
        element.OnRootHacked();
    }

    public void QuitHack()
    {
        actor.curHackableElemet = null;
        actor.OnRootHacked();
        foreach (var item in elements) {
            item.OnQuitHack();
        }
    }

    public ActorController GetActor()
    {
        return this.actor;
    }
}
