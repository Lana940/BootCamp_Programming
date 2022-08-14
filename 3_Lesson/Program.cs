int n = 5;
int [] array = new int [n];
for (int i = 0; i < n; i ++)
     array[i] = Convert.ToInt32(Console.ReadLine()); // числами и выделили 32 позиции
// Console.WriteLine(string.Join(" ", array));     // стринг джоин делает красивый вывод с тем что указали в (" ")10 9 23 -5 6
Console.WriteLine("[" + string.Join(", ", array) + "]"); //[10, 9, 23, 5, 2]
// [4,5,3,1,2]
// O(n)
//[1,2,3,4,5]   - O(n*log n) - sortirowka
// ((5 + 1)/2) * 5  --  O(1) в одно действие сумму элементов массива нашли, сумма арифм прогрессии
// n < n * log(n) + 1  -- показывает что не всегда выгодно  так упрощать, в итоге действий больше чем в цикли:
int summa = 0;
for(int i = 0; i < n; i++)
    summa +=array[i];
Console.WriteLine(summa); 
//O(n)