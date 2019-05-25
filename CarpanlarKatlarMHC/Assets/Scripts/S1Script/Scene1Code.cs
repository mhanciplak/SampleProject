using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Code : MonoBehaviour
{
   
    private bool drag;
    private bool isInTrigger;
    private bool isFull;
    private Vector3 firstPosition;

    private static string firstTrigger, secondTrigger;
    private bool isInFirstTrigger, isInSecondTrigger, isInDoor;
    private static bool obj3Control, obj6Control, obj25Door, obj4Door;

    public Animator Obj25Animator, Obj4Animator;
    public GameObject SuccessPanel;

    // Start is called before the first frame update
    void Start()
    {
        Obj25Animator.enabled = false;
        Obj4Animator.enabled = false;
        firstTrigger = secondTrigger = "";
        isInFirstTrigger = isInSecondTrigger = isInDoor = drag = false;
        firstPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        drag = true;
    }

    void OnMouseDrag()
    {
        if (drag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(mousePos.x, mousePos.y);
        }
    }
    IEnumerator ShowSuccessPanel(GameObject obj)
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 ilkscale1 = Vector3.zero;
        Vector3 sonscale1 = Vector3.one;

        float time1 = 0.4f;
        float timemax1 = time1;

        obj.SetActive(true);
        obj.transform.localScale = Vector3.zero;

        while (time1 > 0)
        {
            time1 -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            obj.transform.localScale = Vector3.Lerp(ilkscale1, sonscale1, (timemax1 - time1) / timemax1);
        }
    }

    private void ReturnToOldPosition()
    {
        this.transform.position = firstPosition;
       // myAnimationComponent = GetComponent<Animation>();
        //this.gameObject.GetComponent<Animator>().enabled = true;
        //myAnimationComponent.Play("AppleAnimaton");

    }

    void OnMouseUp()
    {
        if (isInFirstTrigger && firstTrigger == "" && this.gameObject.name == "r3")
        {
            obj3Control = true;
            firstTrigger = this.gameObject.name;

            CheckObjects();
        }
        else if (isInSecondTrigger && secondTrigger == "" && this.gameObject.name == "n6")
        {
            obj6Control = true;
            secondTrigger = this.gameObject.name;

            CheckObjects();
        }
        else if (this.gameObject.tag == "Others" && isInDoor)
        {
            if (this.gameObject.name == "Obj25")
            {
                obj25Door = true;
                Obj25Animator.Play("Obj25Animation");
                Obj25Animator.enabled = true;

                CheckObjects();
            }
            else
            {
                obj4Door = true;
                Obj4Animator.Play("Obj4Animation");
                Obj4Animator.enabled = true;

                CheckObjects();
            }
        }
        else
        {
            ReturnToOldPosition();
        }
    }

    private void CheckObjects()
    {
        Debug.Log("obj3 " + obj3Control);
        Debug.Log("obj6 " + obj6Control);
        Debug.Log("obj4Door " + obj4Door);
        Debug.Log("obj25Door " + obj25Door);

        if (obj3Control && obj6Control && obj4Door && obj25Door)
        {
            StartCoroutine(Show(SuccessPanel));
        }
    }

    IEnumerator Show(GameObject obj)
    {
        yield return new WaitForSeconds(1.5f);

        Vector3 ilkscale1 = Vector3.zero;
        Vector3 sonscale1 = Vector3.one;

        float time1 = 0.4f;
        float timemax1 = time1;

        obj.SetActive(true);
        obj.transform.localScale = Vector3.zero;

        while (time1 > 0)
        {
            time1 -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            obj.transform.localScale = Vector3.Lerp(ilkscale1, sonscale1, (timemax1 - time1) / timemax1);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Col3")
        {
            isInFirstTrigger = true;
        }
        else if (col.name == "Col6")
        {
            isInSecondTrigger = true;
        }
        else if (col.name == "kapı")
        {
            isInDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Col3")
        {
            isInFirstTrigger = false;
            firstTrigger = "";
        }
        else if (col.name == "Col6")
        {
            isInSecondTrigger = false;
            secondTrigger = "";
        }
        else if (col.name == "kapı")
        {
            isInDoor = false;
        }
    }
}
