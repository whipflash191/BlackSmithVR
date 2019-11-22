using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllor : MonoBehaviour
{
    public static MenuControllor instance;

    public List<GameObject> menuPanels = new List<GameObject>();//0 =inbox, 1 = jobs, 2 = shop
    

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickInboxTabButton()
    {
        menuPanels[0].SetActive(true);
        CloseOtherPanels(menuPanels[0]);
    }
    public void OnClickJobTabButton()
    {
        menuPanels[1].SetActive(true);
        CloseOtherPanels(menuPanels[1]);
    }
    public void OnClickShopTabButton()
    {
        menuPanels[2].SetActive(true);
        CloseOtherPanels(menuPanels[2]);
    }
    
    public void CloseOtherPanels(GameObject panelNottoClose)
    {
        foreach(GameObject mp in menuPanels)
        {
            if(mp != panelNottoClose)
            {
                mp.SetActive(false);
            }
        }
    }

}
