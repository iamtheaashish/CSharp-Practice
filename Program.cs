List<string> words = new List<string>() { "apple", "banana", "corn", "durian"};

Console.WriteLine(words[2]);

words[2] = "coconut";
Console.WriteLine(words[2]);


words.Add("mangu");
Console.WriteLine(words[4]);

words.Insert(2, "Guava");
Console.WriteLine(words[2]);


words.AddRange(new string[] {"apple", "durian"});

words.InsertRange(2, new string[] { "banan", "corn"})



