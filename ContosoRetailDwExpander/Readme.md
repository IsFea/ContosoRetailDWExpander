Создать модель:
~~~
dotnet ef dbcontext scaffold "Server=127.0.0.1,49170;User id=admin;Password=;Database=ContosoRetailDW;TrustServerCertificate=True;"  Microsoft.EntityFrameworkCore.SqlServer -o Model
~~~