using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
	public GameObject turning, loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int sceneIndex)
    {
    	StartCoroutine(LoadAsynch(sceneIndex));
    }

    IEnumerator LoadAsynch(int sceneIndex)
    {
    	AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
    	loadingScreen.SetActive(true);

    	while(!operation.isDone)
    	{
    		Quaternion newRotation = new Quaternion(turning.transform.rotation.x,turning.transform.rotation.y,turning.transform.rotation.z,turning.transform.rotation.w);
        	newRotation *= Quaternion.Euler(0, 0, 90); // this add a 90 degrees Y rotation
        	turning.transform.rotation= Quaternion.Slerp(turning.transform.rotation, newRotation,2.5f * Time.deltaTime);
            yield return null;
    	}
    }
}
