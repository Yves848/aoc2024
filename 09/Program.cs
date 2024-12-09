using System.Collections.Concurrent;
using System.Globalization;

void addToFat(LinkedList<int?> FAT, int? num, int times)
{
  for (int i = 0; i < times; i++)
  {
    FAT.AddLast(num);
  }
}

void part1()
{
  string input = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\09\data.txt").Trim();
  LinkedList<int?> FAT = new LinkedList<int?>();
  int n = 1;
  for (int i = 0; i < input.Length; i++)
  {
    if (i == 0)
    {
      addToFat(FAT, 0, int.Parse(input[i].ToString()));
    }
    else
    {
      var j = (i % 2 == 0) ? n++ : -1;
      addToFat(FAT, j, int.Parse(input[i].ToString()));
    }
  }
  while (FAT.Contains(-1))
  {
    LinkedListNode<int?> last = FAT.Last;
    if (last.Value > -1)
    {
      LinkedListNode<int?> current = FAT.Find(-1);
      current.Value = last.Value;
    }
    FAT.RemoveLast();
  }
  long total = 0;

  foreach (var (item, index) in FAT.Select((value, i) => (value, i)))
  {
    total += (index * item.Value);
  }
  Console.WriteLine($"Total : {total}");
}

void part2()
{
  string input = File.ReadAllText(@"C:\Users\yvesg\git\aoc2024\09\text.txt").Trim();
  LinkedList<int?> FAT = new LinkedList<int?>();
  int n = 1;
  for (int i = 0; i < input.Length; i++)
  {
    if (i == 0)
    {
      addToFat(FAT, 0, int.Parse(input[i].ToString()));
    }
    else
    {
      var j = (i % 2 == 0) ? n++ : -1;
      addToFat(FAT, j, int.Parse(input[i].ToString()));
    }
  }
  List<int> lFAT = FAT.Select((value, i) => ((int)value)).ToList();
  lFAT.ForEach(p=>{Console.Write($"{((p == -1)? "." : p )}");});
  Console.WriteLine();
  int z = lFAT.Count - 1;
  while (z > 1)
  {
    if (lFAT[z] > -1)
    {
      int oldValue = lFAT[z];
      List<int> zs = new List<int>();
      while (oldValue == lFAT[z])
      {
        zs.Add(z);
        z--;
      }
      int i = lFAT.IndexOf(-1);
      int si = i;
      int space = 1;
      while (i < z)
      {
        
        if (space == zs.Count)
        {
          for (int p = 0; p < space; p++)
          {
            lFAT[p + si] = lFAT[zs[p]];
          }
          zs.ForEach(z => lFAT[z] = -1);
          break;
        }
        if (lFAT[i + 1] == -1)
        {
          space++;
          i++;
        }
        else
        {
          space = 1;
          i = lFAT.IndexOf(-1, i + 1);
          si = i;
        }
      }
    }
    else
    {
      z--;
    }
  }
  lFAT.ForEach(p=>{Console.Write($"{((p == -1)? "." : p )}");});
  Console.WriteLine();
  long total = 0;
  int k = 0;
  foreach (int p in lFAT)
  {
    // Console.WriteLine(p);
    if (p > -1)
    {
      total += (k * p);
    }
    k++;
    
  }

  Console.WriteLine($"Total : {total}");
}

//part1();
part2();