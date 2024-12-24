List<long> data = File.ReadAllLines(@"C:\Users\yvesg\git\aoc2024\22\test.txt").ToList().Select(l => long.Parse(l)).ToList();


long mix(long secret, long shift)
{
  return secret ^ shift;
}

long prune(long secret)
{
  return secret % 16777216;
}

long calc(long secret)
{
  secret = mix(secret, secret * 64);
  secret = prune(secret);
  secret = mix(secret / 32, secret);
  secret = prune(secret);
  secret = mix(secret * 2048, secret);
  secret = prune(secret);
  return secret;
}

Dictionary<(int,int, int, int, int), int> bananas = new Dictionary<(int,int, int, int, int), int>();

List<List<(int,int)>> changes = [];
void part1()
{
  long total = 0;
  // data.Clear();
  // data.Add(123);
  
    int buyer = 0;
  data.ToList().ForEach(secret =>
  {
    List<(int,int)> change = [];
    int baseprice = int.Parse(secret.ToString().Substring(secret.ToString().Length - 1));
    for (var i = 0; i < 2000; i++)
    {
      secret = calc(secret);
      int price = int.Parse(secret.ToString().Substring(secret.ToString().Length - 1));
      change.Add((price - baseprice,price));
      baseprice = price;
    }
    changes.Add(change);
    buyer++;
    total += secret;
  });
  Console.WriteLine(total);
}

void part2() {
  int buyer = 0;
  while (buyer < changes.Count) {
    var change = changes[buyer];
    int i = 0;
    while (i < change.Count()-4) {
      (int,int,int,int,int) key = (buyer,change[i].Item1,change[i+1].Item1,change[i+2].Item1,change[i+3].Item1);
      if (!bananas.ContainsKey(key)) {
        bananas.Add(key,change[i+3].Item2);
      }
      i+=1;
    }
    buyer++;
  }
  bananas.ToList().ForEach(banana => {
    Console.WriteLine(banana);
  });
}

part1();

part2();
