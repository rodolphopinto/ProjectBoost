using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movimentVector = new Vector3();
    [SerializeField] float period = 2f;

    float movimentFactor;
    Vector3 startingPos;

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }

        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycle * tau);

        movimentFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movimentFactor * movimentVector;
        transform.position = startingPos + offset;
    }
}
