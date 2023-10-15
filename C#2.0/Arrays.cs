namespace C_2._0
{
    internal class Arrays
    {
        public static int[] ConcatArray(int[,] a)
        {
            var myArr = new int[9];
            int count = 0;
            for(int i = 0; i <a.GetLength(0) ; i++)
            {
                for (int j = 0; j <a.GetLength(1) ; j++)
                {
                    myArr[count] = a[i,j];
                    count++;
                }
            }
            Array.Sort(myArr);
            return myArr;
        }

        public static int[,] Task1(int[] myArr)
        {
            var sortedArr = new int [3, 3];
            var count = 0;
            for (int i = 0;i < 3; i++)
            {
                for(int j = 0;j < 3; j++)
                {
                    sortedArr[i,j] = myArr[count];
                    count++;
                }
            }
            return sortedArr;
        }

    }
}
