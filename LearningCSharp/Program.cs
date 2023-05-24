using System;
using DesignPattern.Singleton;
using Microsoft.Data.SqlClient;

Thread t1 = new(() =>
{
    var instance = UploadService.Instance(1);
});

Thread t2 = new(() =>
{
    var instance = UploadService.Instance(2);
});

t1.Start();
t2.Start();

t1.Join();
t2.Join();


string tenantId1 = "oneTenant";
string connectionString1 = "Data Source=oneServer;Initial Catalog=oneDatabase;User Id=oneUser;Password=onePassword;";

TenantDatabaseConnection connection = TenantDatabaseConnection.GetInstance(tenantId1, connectionString1);
SqlConnection sqlConnection = connection.GetConnection();


string tenantId2 = "twoTenant1";
string connectionString2 = "Data Source=twoServer1;Initial Catalog=twoDatabase1;User Id=twoUser;Password=twoPassword;";

TenantDatabaseConnection connection1 = TenantDatabaseConnection.GetInstance(tenantId2, connectionString2);
SqlConnection sqlConnection1 = connection.GetConnection();

Console.WriteLine("This is the end");