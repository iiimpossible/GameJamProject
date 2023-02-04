using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    public GameObject over;
    public GameObject start;
    public GameObject highLight;
    [SerializeField]
    private ActorController actor;
    [SerializeField]
    public List<SpecialElement> elements = new List<SpecialElement>();
    public SpecialElement curHackableElemet;
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
        this.QuitHackMode();
    }

    public void QuitHack()
    {
        curHackableElemet = null;
        actor.OnRootHacked();
        foreach (var item in elements) {
            item.OnQuitHack();
        }
    }

    public ActorController GetActor()
    {
        return this.actor;
    }

    private int index = 0;
    private SpecialElement m_curSelected;
    public void QuitHackMode()
    {
        GameStateManager.instance.SwitchState(EGameStateType.NomalGame);
        highLight.gameObject.SetActive(false);
    }

    public void EnterHackMode()
    {
        GameStateManager.instance.SwitchState(EGameStateType.HackingGame);
        this.NextHack();
    }
    public void NextHack()
    {
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) {
            if (elements.Count > index) {
                var item = elements[index];
                m_curSelected = item;
                highLight.gameObject.SetActive(true);
                highLight.transform.position = item.transform.position;
                index++;
                if (index >= elements.Count) {
                    index = 0;
                }
            }
        }

    }

    public void LastHack()
    {
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) {
            if (elements.Count > index) {
                var item = elements[index];
                m_curSelected = item;
                highLight.gameObject.SetActive(true);
                highLight.transform.position = item.transform.position;
                index--;
                if (index < 0) {
                    index = elements.Count - 1;
                }
            }
        }
    }

    public SpecialElement GetSelectedElement()
    {
        return m_curSelected;
    }

    public void ActorToStart()
    {
        actor.transform.position = start.transform.position;
    }
}
