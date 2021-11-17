using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProj
{
    public class Animal : MonoBehaviour
    {
        //задаём вид животного
        public string AnimalType {get; set;}
    
        //размеры популяции
        public int Population {get;set;}

        //координаты нужны?
        //тут нужен объект класса Point

    }
}