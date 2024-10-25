using DBLibrary;
using System.Collections.Generic;
using System.Diagnostics;

//Task 5.1
Console.WriteLine("Task 5.1\n");
Console.WriteLine(DAL.ConnectionString);

//Task 5.2.1
Console.WriteLine("\nTask 5.2.1");
await DAL.ChangeConnectionSettings(@"PRSERVER\SQLEXPRESS","ispp3511","ispp3511","3511");
Console.WriteLine(DAL.ConnectionString);

//Task 5.2.2
Console.WriteLine("\nTask 5.2.2");
bool isConnection = await DAL.CheckConnectivity();
Console.WriteLine(isConnection);


//Task 5.3
Console.WriteLine("\nTask 5.3");
var rows = await DAL.CompleteCommand("UPDATE Game SET Price = 150 WHERE GameId = 3");
Console.WriteLine($"Количество изменённых строк: {rows}");

//Task 5.4
Console.WriteLine("\nTask 5.4");
object query = await DAL.GetObject("UPDATE Game SET Price = 150 WHERE GameId = 3");
Console.WriteLine($"Изменённый объект: {query}");