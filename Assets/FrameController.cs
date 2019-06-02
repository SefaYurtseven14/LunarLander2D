using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SmallShips
{



    public class FrameController : BaseFrameController {

        public GameObject parentShip;

        GameObject shipClone;

        public AudioClip audio;
        public AudioSource audioSource;
        public Vector3 startPos;
        bool fold = true;
        public static int life = 5;
        public bool isLandingPlatform = false;
        public  GameObject life1;
        public  GameObject life2;
        public  GameObject life3;
        public  GameObject life4;
        public  GameObject life5;
        public int stageNumber;
        private void Start()
        {
            audioSource.clip = audio;
            
            Init();
        }

        override public void TurnOff()
        {
            base.TurnOff();
            fold = true;
            if (parentShip != null && !IfShip7())
                parentShip.GetComponent<BaseBulletStarter>().StopRepeatFire();
        }

        public void OneShot()
        {
            if (parentShip != null)
            {
                if (IfShip7())
                {
                    parentShip.transform.Find("TurretLeft").GetComponent<BaseBulletStarter>().MakeOneShot();
                    parentShip.transform.Find("TurretRight").GetComponent<BaseBulletStarter>().MakeOneShot();
                } else {
                    parentShip.GetComponent<BaseBulletStarter>().MakeOneShot();
                }
            }
        }
        public void Update()
        {
            if (life == 0)
            {
                Destroy(life1);
                Destroy(life2);
                Destroy(life3);
                Destroy(life4);
                Destroy(life5);
            }
            else if (life == 1)
            {
                Destroy(life2);
                Destroy(life3);
                Destroy(life4);
                Destroy(life5);
            }
            else if (life == 2)
            {
                Destroy(life3);
                Destroy(life4);
                Destroy(life5);
            }
            else if (life == 3)
            {
                Destroy(life4);
                Destroy(life5);
            }
            else if (life == 4)
            {
                Destroy(life5);
            }
        }
        bool IfShip7()
        {
            return parentShip.name.Contains("Ship7");
        }

        public void RepeatFire()
        {
            repeatFire = !repeatFire;
            if (parentShip != null)
            {
                if (repeatFire)
                {
                    if (IfShip7())
                    {
                        parentShip.transform.Find("TurretLeft").GetComponent<BaseBulletStarter>().StartRepeateFire();
                        parentShip.transform.Find("TurretRight").GetComponent<BaseBulletStarter>().StartRepeateFire();
                    } else
                    {
                        parentShip.GetComponent<BaseBulletStarter>().StartRepeateFire();
                    }
                }
                else
                {
                    if (IfShip7())
                    {
                        parentShip.transform.Find("TurretLeft").GetComponent<BaseBulletStarter>().StopRepeatFire();
                        parentShip.transform.Find("TurretRight").GetComponent<BaseBulletStarter>().StopRepeatFire();
                    }
                    else
                    {
                        parentShip.GetComponent<BaseBulletStarter>().StopRepeatFire();
                    }
                }
            }
        }

        public void MakeDestroy()
        {
            if (parentShip != null)
            {
                parentShip.GetComponent<ExplosionController>().StartExplosion();
                if (life > 1)
                {
                    StartCoroutine(Example());
                }
                else
                {
                    SceneManager.LoadScene("GameOver");
                }
                life--;
            }
        }

        public void UnfoldFold()
        {
            if (parentShip != null)
            {
                fold = !fold;
                parentShip.GetComponent<Animator>().SetBool("fold", fold);
            }
        }

        public void SetAnimationTrigger(string trigger)
        {
            if (parentShip != null)
            {
                parentShip.GetComponent<Animator>().SetTrigger(trigger);
            }
        }

        IEnumerator CheckShipDestroy()
        {
            while (parentShip != null)
                yield return new WaitForSeconds(0.1f);

            Invoke("MakeCloneVisible", 2.0f);
        }

        void MakeCloneVisible()
        {
            parentShip = shipClone;
            shipClone = null;
            parentShip.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (isLandingPlatform)
            {
                if (other.gameObject.tag == "Player")
                {
                    Debug.Log(other.gameObject.transform.eulerAngles.z);
                    if (other.gameObject.GetComponent<Rigidbody>().velocity.magnitude > 2.0f || other.gameObject.transform.eulerAngles.z < 160 || other.gameObject.transform.eulerAngles.z > 200)
                    {
                        MakeDestroy();
                        audioSource.Play();

                    }
                    else
                    {
                        StartCoroutine(Load());
                    }
                    //if (other.gameObject.transform.eulerAngles.z < 160 || other.gameObject.transform.eulerAngles.z > 200)
                    //{
                    //    MakeDestroy();
                    //    audioSource.Play();

                    //}
                }
            }
            else
            {
                if (other.gameObject.tag == "Player")
                {
                    MakeDestroy();
                    audioSource.Play();
                }
            }

        }

        void LaunchProjectile()
        {
            OneShot();

        }
        IEnumerator Example()
        {
            print(Time.time);
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            print(Time.time);
        }
        IEnumerator Load()
        {
            yield return new WaitForSeconds(3);
            if (stageNumber == 1)
            {
                SceneManager.LoadScene("LoadScreen2");
            }
            else if (stageNumber == 2)
            {
                SceneManager.LoadScene("LoadScreen3");
            }
            else if (stageNumber == 3)
            {
                SceneManager.LoadScene("LoadScreen4");
            }
        }
    }

}
