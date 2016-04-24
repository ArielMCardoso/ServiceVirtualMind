Instrucciones:

1. Correr el script "Base\SQLBaseUsuariosScript.sql" en un SQL Server Management Studio sobre "master".

2. Editar "src\MyRestfullApp\Web.config". En la línea
	<add name="BaseUsuariosEntities" connectionString="metadata=res://*/UsersEF.csdl|res://*/UsersEF.ssdl|res://*/UsersEF.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ANTHEA\SQLSERVER2008;initial catalog=BaseUsuarios;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  
	Cambiar la parte "data source=ANTHEA\SQLSERVER2008" por el nombre del server en el cual se corrió el script del punto 1.

3. Abrir la solución "src\MyRestfullApp.sln".

4. En el Visual Studio, establecer como proyecto de inicio "MyResfullApp" y ejecutar para probar.

PARA PROBAR LOS TESTS UNITARIOS:
	
5. Editar "src\MyRestfullApp.Tests\app.config" en la línea
	<add name="BaseUsuariosEntities" connectionString="metadata=res://*/UsersEF.csdl|res://*/UsersEF.ssdl|res://*/UsersEF.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=ANTHEA\SQLSERVER2008;initial catalog=BaseUsuarios;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  
	Cambiar la parte "data source=ANTHEA\SQLSERVER2008" por el nombre del server en el cual se corrió el script del punto 1.

6. En el Visual Studio, abrir la ventana de "explorador de pruebas" bajo el Menú de Prueba y ejecutar todas las pruebas.




