using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager instance;

    public GameObject over;
    public GameObject start;
    public SelectFrame highLight;
    public HackBg hackbg;
    [SerializeField]
    private ActorController actor;
    [SerializeField]
    public List<SpecialElement> elements = new List<SpecialElement>();
    public List<FireController> fires = new List<FireController>();
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        var go = GameObject.Find("Bg img");
        if (go != null) {
            hackbg = go.GetComponent<HackBg>();
        }

    }

    // Update is called once per frame
    void Update()
    {
# if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.N)) {
            actor.transform.position = GameObject.Find("SuccessTrigger").transform.position;
        }
#endif
    }


    public void Rigister(SpecialElement element)
    {
        this.elements.Add(element);
    }

    public void RigisterFire(FireController fire)
    {
        this.fires.Add(fire);
    }

    public void RigisterActor(ActorController actor)
    {
        this.actor = actor;
    }

    public void SwichFire()
    {
        foreach (var item in fires) {
            item.Switch();
        }
        Debug.Log("SwichFire " + fires.Count);
    }

    private SpecialElement m_curHackedElement;
    public void EnterHack(SpecialElement element)
    {
        this.QuitHack();
        actor.OnIdle();
        element.OnRootHacked();
        m_curHackedElement = element;
        this.QuitHackMode();
        hackbg?.ShowHacking();
    }

    public void QuitHack()
    {
        actor.OnRootHacked();
        foreach (var item in elements) {
            item.OnQuitHack();
            item.OnOutSelected();
        }
        m_curHackedElement = null;
        hackbg?.CloseHack();
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
        if (IsHacking()) {
            hackbg?.ShowHacking();
        } else {
            hackbg?.CloseHack();
        }

    }

    public void EnterHackMode()
    {
        GameStateManager.instance.SwitchState(EGameStateType.HackingGame);
        foreach (var item in elements) {
            item.OnEnterHackMode();
        }
        hackbg?.ShowStartHack();
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
        Debug.Log("IsHacking " + (m_curHackedElement != null));
        return this.actor.IsIdle();
    }
}
