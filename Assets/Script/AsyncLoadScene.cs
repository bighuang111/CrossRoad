using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Globe
{
    public static string nextSceneName;
}

public class AsyncLoadScene : MonoBehaviour
{
    public Text loadingText;
    public Image progressBar;

    private int curProgressValue = 0;
    private AsyncOperation operation;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "LoadingScene")
        {
            //启动协程
            StartCoroutine(AsyncLoading());
        }
    }

    IEnumerator AsyncLoading()
    {
        operation = SceneManager.LoadSceneAsync(Globe.nextSceneName);
        //阻止当加载完成后自动切换
        operation.allowSceneActivation = false;

        yield return operation;
    }
    // Update is called once per frame
    void Update()
    {
        int progressValue = 100;
        if(curProgressValue < progressValue)
        {
            curProgressValue++;
        }
        loadingText.text = curProgressValue + "%";
        progressBar.fillAmount = curProgressValue / 100f;
        if(curProgressValue == 100)
        {
            operation.allowSceneActivation = true;//启用自动加载场景
            loadingText.text = "加载完成";

        }
    }
}
