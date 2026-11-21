List<Percon> people = new List<Percon>
{
    new Percon("Aliakbar",21),
    new Percon("Safar", 22),
    new Percon("Magomed" , 20)
};

int sum = 0;
people.ForEach( n => sum += n.Age);
System.Console.WriteLine("1. Sum " + sum);
List<Percon> byLength = new List<Percon>(people);
byLength.Sort((a, b) => b.Name.Length.CompareTo(a.Name.Length));
System.Console.WriteLine("2. " + PersonsToString(byLength));


List<Percon> byAge = new List<Percon>(people);
byAge.Sort((a, b) => a.Age.CompareTo(b.Age));
System.Console.WriteLine("3. " + PersonsToString(byAge));

List<Percon> evenOnly = new List<Percon>(people);
evenOnly.RemoveAll(p => p.Age % 2 != 0);
System.Console.WriteLine("4. " + PersonsToString(evenOnly));

System.Console.Write("5. ");
people.ForEach(p => System.Console.Write(p.Name.ToUpper() + " "));
System.Console.WriteLine();
int max = people[0].Age;
int min = people[0].Age;
people.ForEach(p =>
{
    if (p.Age > max) max = p.Age;
    if (p.Age < min) min = p.Age;
});
System.Console.WriteLine("6. Max " + max + ", Min  " + min);
System.Console.WriteLine("7.");
people.ForEach(p =>
{
    string lower = p.Name.ToLower();
    bool unique = new HashSet<char>(lower).Count == lower.Length;
    System.Console.WriteLine("   " + p.Name + ": " + unique);
});


double avg = (double)sum / people.Count;
System.Console.WriteLine("8. Average age: " + avg);

List<Percon> uniqueAges = new List<Percon>();
HashSet<int> seen = new HashSet<int>();
people.ForEach(p =>
{
    if (seen.Add(p.Age))
    {
        uniqueAges.Add(p);
    }
});
System.Console.WriteLine("9." + PersonsToString(uniqueAges));

System.Console.WriteLine("10.");
people.ForEach(p => System.Console.WriteLine("   " + p.Name + ": " + IsPalindrome(p.Name.ToLower())));


List<Percon> age20 = people.FindAll(p => p.Age == 20);
System.Console.WriteLine("11. Age 20: " + PersonsToString(age20));
string joined = "";
for (int i = 0; i < people.Count; i++)
{
    joined += people[i].Name;
    if (i < people.Count - 1)
    {
        joined += ";";
    }
}
System.Console.WriteLine("12. " + joined);

int oddIndexSum = 0;
for (int i = 1; i < people.Count; i += 2)
{
    oddIndexSum += people[i].Age;
}
System.Console.WriteLine("13. " + oddIndexSum);

Percon longest = people[0];
people.ForEach(p =>
{
    if (p.Name.Length > longest.Name.Length) longest = p;
});
System.Console.WriteLine("14. " + longest.Name);

List<Percon> byName = new List<Percon>(people);
byName.Sort((a, b) => string.Compare(a.Name, b.Name));
System.Console.WriteLine("15 " + PersonsToString(byName));

int target = 42;
System.Console.WriteLine("16." + target + ":");
for (int i = 0; i < people.Count; i++)
{
    for (int j = i + 1; j < people.Count; j++)
    {
        if (people[i].Age + people[j].Age == target)
        {
            System.Console.WriteLine("   " + people[i].GetInfo() + " + " + people[j].GetInfo());
        }
    }
}


List<Percon> aboveAverage = people.FindAll(p => p.Age > avg);
System.Console.WriteLine("17. " + PersonsToString(aboveAverage));

List<Percon> withoutSub = new List<Percon>(people);
withoutSub.RemoveAll(p => p.Name.ToLower().Contains("an"));
System.Console.WriteLine("18.  " + PersonsToString(withoutSub));

List<Percon> absolute = people.ConvertAll(p => new Percon(p.Name, Math.Abs(p.Age)));
System.Console.WriteLine("19. " + PersonsToString(absolute));


Dictionary<int, List<Percon>> groups = new Dictionary<int, List<Percon>>();
people.ForEach(p =>
{
    if (!groups.ContainsKey(p.Age))
    {
        groups[p.Age] = new List<Percon>();
    }
    groups[p.Age].Add(p);
});
System.Console.WriteLine("20. ");
foreach (var pair in groups)
{
    System.Console.WriteLine("   Age " + pair.Key + ": " + PersonsToString(pair.Value));
}

bool IsPalindrome(string s)
{
    for (int i = 0; i < s.Length / 2; i++)
    {
        if (s[i] != s[s.Length - 1 - i])
        {
            return false;
        }
    }
    return true;
}

string PersonsToString(List<Percon> list)
{
    string res = "";
    for (int i = 0; i < list.Count; i++)
    {
        res += list[i].GetInfo();
        if (i < list.Count - 1)
        {
            res += ", ";
        }
    }
    return res;
}