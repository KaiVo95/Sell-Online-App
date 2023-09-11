### Generate code from database
https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell
Important: never change any code in folder "Models" manually

- Set startup project to WebApiApp
- Tools –> NuGet Package Manager –> Package Manager Console
- Run the following command to create a model from the existing database:
> Scaffold-DbContext "Server=.\SQLEXPRESS;Database=SellOnlineApiApp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models

- Vs Code scaffold command
> dotnet ef dbcontext scaffold "Server=.\SQLEXPRESS;Database=SellOnlineApiApp;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models