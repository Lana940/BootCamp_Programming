int [] array ={ 0, 2, 3, 2, 1, 7, 8, 6, 0, 2, 3, 5, 9, 1, 1};
CountingSort(array);
Console.WriteLine(string.Join(", ", array));

void CountingSort(int [] inputArray)
{                                      // создаем вспомогательный массив, который будет подсчитывать кол-во уник ел
   int [] counters = new int [10]; //выделили память в размере 10, т.к в нашем массиве цифры от 0 до 10   
   

   for (int i = 0; i < inputArray.Length; i++)
   {
    //в этой строке содержатся 2 нижние, как вариант :counters[inputArray[i]]++;  во 2 массиве увеличиваем ячейку эл над кот сейчас работает, 
    int ourNumber = inputArray[i];// то число, которое мы в данный момент обходим ex:0 на первой итерации, в массиве counters превращается в 1
    counters[ourNumber]++; // el massiva counters po indexy ourNumber uvelichivaetsya kak na kartinke
    
   }
   // меняем все в старом массиве, без создания новой, но можно и так и так

    int index = 0; //отдельный индекс, нужен для хождения по ел исходного массива
    for (int i = 0; i<counters.Length; i++) // обходим все повторяюшиеся ел
    {
        for (int j = 0; j<counters[i]; j++) // вложенный цикл должен выполнится столько раз сколько у нас ел povtoryaetsq в массиве, поетому counters [i]
        {
            inputArray[index] = i; //zapisyvaem nash ishodniy massiv по индексу = 0 наши повторения
            index++;

        }
    }
    

}