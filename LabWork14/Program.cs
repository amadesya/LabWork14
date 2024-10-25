using DBLibrary;


Console.WriteLine(DAL.ConnectionString);

await DAL.ChangeConnectionSettings(@"PRSERVER\SQLEXPRESS","ispp3511","ispp3511","3511");
Console.WriteLine(DAL.ConnectionString);