using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityProj {
    public class Graph : MonoBehaviour
    {
        public int scale = 1;
        private LineRenderer lineRenderer;
        private Vector3 ZeroCoordinates;
        [SerializeField] private Canvas backgroundPanel;
        [SerializeField] private LotkaVolterraModel lotkaVolterra;
        public String TypeOfCreatures;

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            ZeroCoordinates = GameObject.FindGameObjectWithTag("ZeroCoordinates").gameObject.transform.position;
        }

        private void Update()
        {
            if (backgroundPanel.enabled)
            {
                lotkaVolterra.FindPredicts();
                if (TypeOfCreatures.ToLower() == "preys")
                {
                    lineRenderer.startColor = Color.blue;
                    lineRenderer.endColor = Color.blue;
                    Debug.Log(lotkaVolterra.PreysPredict.GetValue(1));
                    Draw(lotkaVolterra.PreysPredict, lotkaVolterra.Preys);
                }

                if (TypeOfCreatures.ToLower() == "predators")
                {
                    lineRenderer.startColor = Color.red;
                    lineRenderer.endColor = Color.red;
                    Debug.Log(lotkaVolterra.PredatorsPredict.GetValue(2));
                    Draw(lotkaVolterra.PredatorsPredict, lotkaVolterra.Predators);
                }
            }
            if (!backgroundPanel.enabled)
            {
                Clear();
            }
        }

        private void Draw(double[] predictions, double startPos)
        {
            Vector3 startPoint = new Vector3(0, (float)startPos, 0);
            Vector3[] Tops = ConvertDoubleToVector3(predictions);

            lineRenderer.gameObject.transform.position = ZeroCoordinates;
            lineRenderer.positionCount = Tops.Length + 1;
            lineRenderer.SetPosition(0, startPoint);
            //lineRenderer.SetPositions(Tops);
            for (int i = 1; i <= Tops.Length; i++)
            {
                lineRenderer.SetPosition(i, Tops[i-1]);
            }
        }

        private Vector3[] ConvertDoubleToVector3(double[] array)
        {
            Vector3[] result = new Vector3[array.Length];
            for(int i = 1; i <= array.Length; i++)
            {
                result[i-1] = new Vector3((float)(lotkaVolterra.StepSize * i * scale), (float)array[i - 1] * scale, 0);
            }
            return result;
        }

        private void Clear()
        {
            lineRenderer.positionCount = 0;
        }
    }
}