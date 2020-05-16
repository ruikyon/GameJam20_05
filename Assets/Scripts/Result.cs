using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public static Result instance;
    [SerializeField] private TextMeshProUGUI time, comment, successText, failText;
    bool success;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene("Start");
        }
    }

    public static void Show(string time, string comment, bool success) 
    {
        instance.time.text = time;
        instance.comment.text = comment;
        instance.success = success;
        instance.StartCoroutine(instance.ShowResult());
    }

    private IEnumerator ShowResult() 
    {
        yield return new WaitForSeconds(1);
        time.gameObject.SetActive(true);
        SEManager.Play(SEManager.ClipName.Don);
        yield return new WaitForSeconds(1);
        comment.gameObject.SetActive(true);
        SEManager.Play(SEManager.ClipName.Dondon);
        yield return new WaitForSeconds(1);
        (success ? successText : failText).gameObject.SetActive(true);
        SEManager.Play(success?SEManager.ClipName.Success:SEManager.ClipName.Fail);
    }
}
