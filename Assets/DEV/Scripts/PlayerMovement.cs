using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameEnums;
using static UnityEngine.GridBrushBase;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    #region Fields
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 90;
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator ac;
    [SerializeField] AudioHelper audioHelper;
    Direction direction;
    bool isClicked = false, isTurning;
    float v;
    Vector3 moveInput;
    Coroutine rotateCoroutine;
    #endregion

    #region Core
    public void Initialize()
    {
        setAnimValues();
    }
    #endregion

    #region Execute
    public void SetDirection(Direction dir)
    {
        direction = dir;
    }
    public void SetClickBool(bool isClicked)
    {
        StopDancing();
        this.isClicked = isClicked;
        if (isClicked)
        {
            switch (direction)
            {
                case Direction.Right:
                    isTurning = true;
                    RotateRight();
                    break;
                case Direction.Left:
                    isTurning = true;
                    RotateLeft();
                    break;
                case Direction.Forward:
                    isTurning = false;
                    MoveForward();
                    break;
            }
        }
        else
        {
            if (rotateCoroutine != null)
            {
                StopCoroutine(rotateCoroutine);
            }
            isTurning = false;
        }
    }

    public void RotateRight()
    {
        isTurning = true;
        ac.SetBool("isTurning", true);
        ac.SetFloat("Turn", 1);
        rotateCoroutine = StartCoroutine(RotateOverTime(Vector3.up, rotationSpeed));
        setAnimValues();
    }

    public void RotateLeft()
    {
        isTurning = true;
        ac.SetBool("isTurning", true);
        ac.SetFloat("Turn", 0);
        rotateCoroutine = StartCoroutine(RotateOverTime(-Vector3.up, rotationSpeed));
        setAnimValues();
    }

    public void MoveForward()
    {
        ac.SetBool("isTurning", false);
        v = 1.0f;
        setAnimValues();
    }
    private void setAnimValues()
    {
        ac.SetFloat("MoveSpeed", Mathf.Abs(v));
    }
    public void Stop()
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
        }
        isTurning = false;
        v = 0.0f;
        setAnimValues();
        ac.SetBool("isTurning", false);
        ac.SetFloat("Turn", 0);

    }

    private IEnumerator RotateOverTime(Vector3 axis, float speed)
    {
        while (isTurning)
        {
            transform.Rotate(axis, speed * Time.deltaTime);
            yield return null;
        }
        Stop();
    }

    private void Update()
    {
        if (isClicked)
        {
            if (!isTurning)
            {
                moveInput = new Vector3(0, 0, v);
                transform.position += transform.forward * moveInput.z * moveSpeed * Time.deltaTime;

            }
        }
    }
    #endregion

    #region Collisions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            print("gem collected");
            audioHelper.PlayCollectSound();
            other.GetComponentInParent<Gem>().Dismiss();
            PlayerDataModel.Data.Score += 1;
            PlayerDataModel.Data.Save();
        }
        if (other.CompareTag("Door"))
        {
            //print(other.name);
            other.GetComponent<Animator>().SetBool("character_nearby", true);

        }
    }
    #endregion

    #region Dance Anims
    UnityEngine.UI.Button button;
    public void StartDancing(UnityEngine.UI.Button button)
    {
        this.button = button;
        Stop();
        button.enabled = false;
        audioHelper.PlayDanceSound();
        ac.SetBool("Dance", true);
    }
    public void StopDancing()
    {
        if (button != null)
            button.enabled = true;
        audioHelper.Stop();
        ac.SetBool("Dance", false);
    }
    #endregion
}
