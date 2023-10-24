Создать модель:
~~~
dotnet ef dbcontext scaffold "Server=127.0.0.1,49170;User id=admin;Password=;Database=ContosoRetailDW;TrustServerCertificate=True;"  Microsoft.EntityFrameworkCore.SqlServer -o Model
~~~

Загрузка CSV в Postgress
~~~
\COPY "DimProduct" FROM 'Q://NewContosoDB/dimProduct.csv' DELIMITER '|' CSV HEADER
~~~