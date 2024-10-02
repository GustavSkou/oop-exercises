long pow(int a, int n) {
      if (n == 0) {
            return 1;
      }
      return a * pow(a, n-1);
}

int getUserIntergerInput() {
      try {
            string input = Console.ReadLine();
            int a = Convert.ToInt32(input);
            return a;
      }
      catch (FormatException e) {
            Console.WriteLine($"Input er ikke en interger, input har typen {typeof(e)}\n{e}");
            return getUserIntergerInput();
      }

}

int a, e;
Console.WriteLine($"{a = getUserIntergerInput() }^{e = getUserIntergerInput() } = {pow(a, e)}");