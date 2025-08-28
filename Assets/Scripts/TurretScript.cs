using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class TurretScript : MonoBehaviour
{
    GameObject[] police, vanPolice;
    public List<GameObject> allPolice;
    public GameObject bullet;
    public Animator anim;
    int level, shots;
    public CinemachineVirtualCamera VirtualCamera;
    bool go;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("TourelleLevel", 1);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!go)
        {
            VirtualCamera.LookAt = GameObject.FindGameObjectWithTag("Bullet").transform;
            VirtualCamera.Follow = GameObject.FindGameObjectWithTag("Bullet").transform;
        }*/
    }

    public void Shoot()
    {
        StartCoroutine(SetUp());
        StartCoroutine(Sleep());
    }

    IEnumerator Sleep()
    {
        yield return new WaitForSecondsRealtime(5);
        anim.SetBool("out", false);
    }

    IEnumerator SetUp()
    {
        anim.SetBool("out", true);
        yield return new WaitForSecondsRealtime(.5f);

        police = GameObject.FindGameObjectsWithTag("Police");
        vanPolice = GameObject.FindGameObjectsWithTag("VanPolice");
        allPolice.Clear();


        if (police != null)
        {
            for (int i = 0; i < police.Length; i++)
            {
                allPolice.Add(police[i]);
            }
        }
        if (vanPolice != null)
        {
            for (int i = 0; i < vanPolice.Length; i++)
            {
                allPolice.Add(vanPolice[i]);
            }
        }

        if (allPolice.Count > 0)
        {
            List<GameObject> sortedList = allPolice
            .OrderBy(obj => Vector3.Distance(this.transform.position, obj.transform.position))
            .ToList();

            for (int i = 0; i < level; i++)
            {
                transform.LookAt(sortedList[0].transform);
                GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                _bullet.GetComponent<BulletScript>().target = sortedList[0];
                sortedList.RemoveAt(0);
                yield return new WaitForSecondsRealtime(.3f);
            }
        }



        anim.SetBool("out", false);
    }

    /*IEnumerator SetUp()
    {
        anim.SetBool("out", true);
        yield return new WaitForSecondsRealtime(.5f);

        police = GameObject.FindGameObjectsWithTag("Police");
        

        if (police != null)
        {
            if(level <= police.Length)
            {
                for (int i = 0; i < level; i++)
                {
                    transform.LookAt(police[i].transform);
                    GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    _bullet.GetComponent<BulletScript>().target = police[i];
                    yield return new WaitForSecondsRealtime(.3f);
                    go = true;
                }
                vanPolice = GameObject.FindGameObjectsWithTag("VanPolice");
                if (level - police.Length > 0 && vanPolice != null)
                {
                    for (int i = 0; i < level - police.Length; i++)
                    {
                        transform.LookAt(vanPolice[i].transform);
                        GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                        _bullet.GetComponent<BulletScript>().target = vanPolice[i];
                        yield return new WaitForSecondsRealtime(.3f);
                    }
                }
            }
            else
            {
                for (int i = 0; i < police.Length; i++)
                {
                    transform.LookAt(police[i].transform);
                    GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                    _bullet.GetComponent<BulletScript>().target = police[i];
                    yield return new WaitForSecondsRealtime(.3f);
                    go = true;
                }
                Debug.Log("here");
                vanPolice = GameObject.FindGameObjectsWithTag("VanPolice");
                Debug.Log(vanPolice.Length);
                if (level - police.Length > 0 && level - police.Length <= vanPolice.Length && vanPolice != null)
                {
                    int shotB = 0;
                    for (int i = 0; i < level - police.Length && shotB < level - police.Length; i++)
                    {
                        transform.LookAt(vanPolice[i].transform);
                        GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                        _bullet.GetComponent<BulletScript>().target = vanPolice[i];
                        yield return new WaitForSecondsRealtime(.3f);
                        shotB += 1;
                    }
                }
                else
                {
                    if(level - police.Length > vanPolice.Length)
                    {
                        for (int i = 0; i < vanPolice.Length; i++)
                        {
                            transform.LookAt(vanPolice[i].transform);
                            GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                            _bullet.GetComponent<BulletScript>().target = vanPolice[i];
                            yield return new WaitForSecondsRealtime(.3f);
                        }
                    }
                }
            }

            /*for (int i = 0; i < police.Length; i++)
            {
                transform.LookAt(police[i].transform);
                GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                _bullet.GetComponent<BulletScript>().target = police[i];
                yield return new WaitForSecondsRealtime(.3f);
                
                go = true;
            }*
        }
        else
        {
            vanPolice = GameObject.FindGameObjectsWithTag("VanPolice");
            if (vanPolice != null)
            {
                if(level >= vanPolice.Length)
                {
                    for (int i = 0; i < level; i++)
                    {
                        transform.LookAt(vanPolice[i].transform);
                        GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                        _bullet.GetComponent<BulletScript>().target = vanPolice[i];
                        yield return new WaitForSecondsRealtime(.3f);
                    }
                }
                else
                {
                    for (int i = 0; i < vanPolice.Length; i++)
                    {
                        transform.LookAt(vanPolice[i].transform);
                        GameObject _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
                        _bullet.GetComponent<BulletScript>().target = vanPolice[i];
                        yield return new WaitForSecondsRealtime(.3f);
                    }
                }
                
            }
        }

        

        anim.SetBool("out", false);
    }*/
}
