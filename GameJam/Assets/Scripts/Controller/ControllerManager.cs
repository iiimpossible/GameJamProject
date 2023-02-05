using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    public GameObject over;
    public GameObject start;
    public SelectFrame highLight;
    [SerializeField]
    private ActorController actor;
    [SerializeField]
    public List<SpecialElement> elements = new List<SpecialElement>();
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

    private SpecialElement m_curHackedElement;
    public void EnterHack(SpecialElement element)
    {
        this.QuitHack();
        actor.OnIdle();
        element.OnRootHacked();
        this.QuitHackMode();
        m_curHackedElement = element;
    }

    public void QuitHack()
    {
        actor.OnRootHacked();
        foreach (var item in elements) {
            item.OnQuitHack();
            item.OnOutSelected();
        }
        m_curHackedElement = null;
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
        //highLight.gameObject.SetActive(false);
        foreach (var item in elements) {
            item.OnQuitHackMode();
        }
    }

    public void EnterHackMode()
    {
        GameStateManager.instance.SwitchState(EGameStateType.HackingGame);
        foreach (var item in elements) {
            item.OnEnterHackMode();
        }
        this.NextHack();
    }
    public void NextHack()
    {
        this.CloseAllArrow();
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) {
            if (elements.Count > index) {
                var item = elements[index];
                m_curSelected = item;
                //highLight.gameObject.SetActive(true);
                var render = item.OnSelected();
                //highLight.Locate(render);
                //highLight.transform.position = item.transform.position;
                index++;
                if (index >= elements.Count) {
                    index = 0;
                }
            }
        }

    }

    private void CloseAllArrow()
    {
        foreach (var item in elements) {
            item.OnOutSelected();
        }
    }

    public void LastHack()
    {
        this.CloseAllArrow();
        if (GameStateManager.instance.GetGameStateType() == EGameStateType.HackingGame) {
            if (elements.Count > index) {
                var item = elements[index];
                m_curSelected = item;
                item.OnSelected();
                //highLight.gameObject.SetActive(true);
                //highLight.transform.position = item.transform.position;
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
        AudioManager.instance.PlayStart();
        actor.transform.position = start.transform.position;
    }

    public bool IsHacking()
    {
        return m_curHackedElement != null;
    }
}
