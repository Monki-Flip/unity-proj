using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GameObject;


namespace UnityProj {
    public class Graph : MonoBehaviour
    {
        //public int scale = 1;
        private LineRenderer lineRenderer;
        private Vector3 ZeroCoordinates;
        private static RectTransform StartPoint;
        [SerializeField] private Canvas backgroundPanel;
        [SerializeField] private LotkaVolterraModel lotkaVolterra;
        public String TypeOfCreatures;

        // делегат события, что график достиг нужного количества зверей обеих популяций
        public delegate void ActionToWin(bool gotIt);
        private bool PreysOnLimit = false;
        private bool PredatorsOnLimit = false;
        public event ActionToWin GraphGotResultAmounts;

        // макс. количество хищников и жертв
        private float PredatorsLimit;
        private float PredatorsMaxCount;
        private float PreysLimit;
        private float PreysMaxCount;

        private float LineRendererStartWidth = 0.07f;
        private float LineRendererEndWidth = 0.08f;
        

        private void Start()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.alignment = LineAlignment.View;

            StartPoint = FindGameObjectWithTag("ZeroCoordinates").GetComponent<RectTransform>();
            float startX = StartPoint.position.x;
            float startY = StartPoint.position.y;

            PredatorsLimit = FindGameObjectWithTag("PredatorsLimit").GetComponent<RectTransform>().position.y * (float)(1/100);
            PreysLimit = FindGameObjectWithTag("PreysLimit").GetComponent<RectTransform>().position.y * (float)(1/100);
            //ZeroCoordinates = new Vector3(startX, startY);
            //ZeroCoordinates = new Vector3(8.759827f, -90.36424f, 0);
            //zeroCoordinates = GameObject.FindGameObjectWithTag("ZeroCoordinates").GetComponent<RectTransform>();
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
                    lineRenderer.startWidth = LineRendererStartWidth;
                    lineRenderer.endWidth = LineRendererEndWidth;
                    Draw(lotkaVolterra.PreysPredict, lotkaVolterra.Preys, PreysMaxCount);
                    //Draw(CreateNewRandomDoubleArray(2500), lotkaVolterra.Preys);
                    
                    if (IfGraphGetsTheResult())
                    {
                        PreysOnLimit = true;
                        //посылай сигнал о событии
                    }
                }

                if (TypeOfCreatures.ToLower() == "predators")
                {
                    lineRenderer.startWidth = LineRendererStartWidth;
                    lineRenderer.endWidth = LineRendererEndWidth;
                    lineRenderer.startColor = Color.red;
                    lineRenderer.endColor = Color.red;
                    Draw(lotkaVolterra.PredatorsPredict, lotkaVolterra.Predators, PredatorsMaxCount);
                    //Draw(CreateNewRandomDoubleArray(2500), lotkaVolterra.Predators);
                    if (IfGraphGetsTheResult())
                    {
                        PredatorsOnLimit = true;
                        //посылай сигнал о событии
                    }
                }
            }
            if (!backgroundPanel.enabled)
            {
                Clear();
            }
        }

        // НЕ СДЕЛАН. должен давать true, когда график достиг максимума(!) на пределе
        private bool IfGraphGetsTheResult()
        {
            var yStep = transform.parent.GetComponent<RectTransform>().rect.height * 1 / 100;
            // переводим координаты лимита в высоту Y

            return false;
        }

        //private double[] CreateNewRandomDoubleArray(int v)
        //{
        //    System.Random random = new System.Random();
        //    double[] array = new double[v];
        //    for (int i = 0; i < v; i++)
        //    {
        //        array[i] = (double)(int)random.Next(1, 100);
        //    }
        //    return array;
        //}

        private void Draw(double[] predictions, double startPos, float currentAnimalsMaxCount)
        {
            Vector3 startPoint = new Vector3(0, (float)startPos);
            Vector3[] Tops = ConvertDoubleToVector3(predictions, currentAnimalsMaxCount);

            lineRenderer.gameObject.transform.localPosition = /*ZeroCoordinates;*/ startPoint;
            lineRenderer.positionCount = Tops.Length + 1;
            lineRenderer.SetPosition(0, startPoint);
            for (int i = 1; i <= Tops.Length; i++)
            {
                lineRenderer.SetPosition(i, Tops[i-1]);
            }
        }

        private Vector3[] ConvertDoubleToVector3(double[] array, float curAnimalsMaxCount)
        {
            var xStep = transform.parent.GetComponent<RectTransform>().rect.width * 1 / 2500;
            var yStep = transform.parent.GetComponent<RectTransform>().rect.height * 1 / 100;
            Vector3[] result = new Vector3[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                result[i] = new Vector3((float)(xStep * i), (float)array[i] * yStep);
                
                if (yStep == curAnimalsMaxCount)
                {
                    //return;
                }
            }

            

            return result;
        }

        private void Clear()
        {
            lineRenderer.positionCount = 0;
        }
    }
}