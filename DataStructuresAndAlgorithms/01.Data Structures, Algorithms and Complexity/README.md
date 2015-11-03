## Data Structures, Algorithms and Complexity
### _Homework_
#### _Task 1_
1. What is the expected running time of the following C# code? Explain why.
  - Assume the array's size is `n`.


			long Compute(int[] arr)
			{
			    long count = 0;
			    for (int i=0; i<arr.Length; i++)
			    {
			        int start = 0, end = arr.Length-1;
			        while (start < end)
			            if (arr[start] < arr[end])
			                { start++; count++; }
			            else 
			                end--;
			    }
			    return count;

#### _Answer_
The outter `for` loop iterates `n` times and for each iteration the inner `while` loop iterates `n` times.
`n` is the input array length.

The expected running time  is `O(n*n)`. 



#### _Task 2_
2. What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

			long CalcCount(int[,] matrix)
			{
			    long count = 0;
			    for (int row=0; row<matrix.GetLength(0); row++)
			        if (matrix[row, 0] % 2 == 0)
			            for (int col=0; col<matrix.GetLength(1); col++)
			                if (matrix[row,col] > 0)
			                    count++;
			    return count;
			}
#### _Answer_
The outter loop iterates `n` times and only if the current digit in the matrix is even the inner loop iterates m-1 times.

The expected running time  is `O(n*m)` (Quadratic Complexity)

#### _Task 3_
3. * What is the expected running time of the following C# code?
  - Explain why.
  - Assume the input matrix has size of n * m.

			long CalcSum(int[,] matrix, int row)
			{
			    long sum = 0;
			    for (int col = 0; col < matrix.GetLength(0); col++) 
			        sum += matrix[row, col];
			    if (row + 1 < matrix.GetLength(1)) 
			        sum += CalcSum(matrix, row + 1);
			    return sum;
			}
			
			Console.WriteLine(CalcSum(matrix, 0));
#### _Answer_
The loop iterates `n` times and the method is calling himself `m` times.

The expected running time  is `O(n*m)` (Quadratic Complexity)