long pow(int a, int n) {
      if (n == 0){
            return 1;
      }
      return a * pow(a, n-1);
}

Console.WriteLine(pow(2, 2));
Console.WriteLine(pow(10, 10));
Console.WriteLine(pow(100, 0));