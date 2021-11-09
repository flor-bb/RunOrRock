using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBirdSpawner : MonoBehaviour
{

    [SerializeField] private GameObject attackBird;

    void Start()
    {

    }


    public void SpawnAttackBirds()
    {

        StartCoroutine(DelayBird());

        GameManager.Instance.setHelpCounter((GameManager.Instance.getHelpCounter() - 1));

    }

    IEnumerator DelayBird()

    {

        int x = 8;
        ArrayList usedNumbers = new ArrayList();
        usedNumbers.Add(x);
        float delay = Random.Range(0.1f, 0.4f); ;

        for (int i = 0; i < 9; i++)
        {
            usedNumbers.Add(x);


            switch (x)
            {



                case 0:
                    Instantiate(attackBird, new Vector3(20, -0.93f, transform.position.z), Quaternion.identity);


                    yield return new WaitForSeconds(delay);

                    break;
                case 1:
                    Instantiate(attackBird, new Vector3(20, 1.25f, transform.position.z), Quaternion.identity);


                    yield return new WaitForSeconds(delay);

                    break;
                case 2:
                    Instantiate(attackBird, new Vector3(20, 3.4f, transform.position.z), Quaternion.identity);

                    yield return new WaitForSeconds(delay);

                    break;
                case 3:
                    Instantiate(attackBird, new Vector3(20, 5.55f, transform.position.z), Quaternion.identity);

                    yield return new WaitForSeconds(delay);

                    break;
                case 4:


                    Instantiate(attackBird, new Vector3(20, 7.7f, transform.position.z), Quaternion.identity);

                    yield return new WaitForSeconds(delay);

                    break;
                case 5:
                    Instantiate(attackBird, new Vector3(20, 10.1f, transform.position.z), Quaternion.identity);

                    yield return new WaitForSeconds(delay);

                    break;
                case 6:


                    Instantiate(attackBird, new Vector3(20, 12.1f, transform.position.z), Quaternion.identity);

                    yield return new WaitForSeconds(delay);

                    break;
                case 7:


                    Instantiate(attackBird, new Vector3(20, 14.18f, transform.position.z), Quaternion.identity);

                    yield return new WaitForSeconds(delay);

                    break;
                case 8:


                    Instantiate(attackBird, new Vector3(20, 16.18f, transform.position.z), Quaternion.identity);


                    yield return new WaitForSeconds(delay);

                    break;

            }

            do
            {
                x = Random.Range(0, 9);
            } while (IsNumberInArrayList(usedNumbers, x) && (i + 1) != 9);
            delay = Random.Range(0.1f, 0.3f);
        }



    }


    private bool IsNumberInArrayList(ArrayList list, int x)
    {

        for (int i = 0; i < list.Count; i++)
        {
            if (x.Equals(list[i]))
            {
                return true;
            }

        }


        return false;

    }


}
