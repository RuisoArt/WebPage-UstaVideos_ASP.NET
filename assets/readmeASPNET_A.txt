> Extenciones Visual Studio Code
	C#
	Doki Theme
	Material Icon Theme
	MongoDB for VS Code
	Prettier
	Spanish Language Pack for Visual
	Tabnine
	vscode-icons
	Extencion Nuget Package Manager

> Instalar versiones distintas de SDK de .NET:
	https://dotnet.microsoft.com/en-us/download

> En powershell Instalar .NET y ejecutar un proyecto/solucion:
	Navegar a carpeta donde se quiere trabajar:
		cd 'direccion local'
		md 'carpeta'

	Instalar todo el ambiente de .NET:
		winget install Microsoft.DotNet.SDK.7
		winget install Microsoft.DotNet.DesktopRuntime.7
		winget install Microsoft.DotNet.AspNetCore.7
		winget install Microsoft.DotNet.Runtime.7
	
	Averiguar donde estan los SDK:
		where.exe dotnet
	
	Cambios de variables de entorno para reconocer el SDK:
		https://learn.microsoft.com/es-es/dotnet/core/install/windows?tabs=net70#it-was-not-possible-to-find-any-installed-net-core-sdks

	dotnet new mvc --auth Individual --name ustaVideosA

	code .	
	
> Iniciar servicios en WSL Ubuntu:
	sudo service apache2 start
	sudo service mariadb start

	http://localhost/phpmyadmin/
		Usuario: root
		Clave: 159951

	listar usuarios:
		mysql -u root -p
		159951
		SELECT User FROM mysql.user

> Iniciar un proyecto/solucion en VS Code
	https://learn.microsoft.com/es-es/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-7-0
	
	dotnet run

> Crear base de datos phpmyadmin
	nombre: db_ustavideos
	utf8mb4_general_ci

	privilegios:
		agregar cuenta de usuario
			nombre: usr_ustavideos
			host: usr_admin_ustavideos
			contraseña: 159951#ustaFN
			authentication plugin: authentication de MySQL nativo
			base de datos para la cuenta de usuario: otorgar todos los privilegios para la base de datos db_....
			Datos: all
			Estructuras : all
			Administracion: all
			SSL: require none

			CREATE USER 'usr_admin_ustavideos'@'%' IDENTIFIED VIA mysql_native_password USING '***';GRANT ALL PRIVILEGES ON *.* TO 'usr_admin_ustavideos'@'%' REQUIRE NONE WITH GRANT OPTION MAX_QUERIES_PER_HOUR 0 MAX_CONNECTIONS_PER_HOUR 0 MAX_UPDATES_PER_HOUR 0 MAX_USER_CONNECTIONS 0;GRANT ALL PRIVILEGES ON `db_ustavideos`.* TO 'usr_admin_ustavideos'@'%';

> appsettings.json:
	{
		"ConnectionStrings": {
			"DefaultConnection": "Server=localhost; Database=db_ustavideos; Uid=usr_admin_ustavideos; Pwd=159951#ustaFN;"
		},
		"Logging": {
			"LogLevel": {
			"Default": "Information",
			"Microsoft.AspNetCore": "Warning"
			}
		},
		"AllowedHosts": "*"
	}

> NUGET:
	https://learn.microsoft.com/es-es/nuget/consume-packages/install-use-packages-powershell

	dentro de la ruta de aplicacaion:
		dotnet add package Pomelo.EntityFrameworkCore.MySql
		dotnet add package Pomelo.EntityFrameworkCore.MySql.Design

> Program.cs

	// Add services to the container.
	var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
	builder.Services.AddDbContext<ApplicationDbContext>(options =>
		//options.UseSqlite(connectionString)
		options.UseMySql(
			connectionString,
			Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.23-mysql")
		)
	);	

"dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0" este comando es para instalar el driver de mariadb/mysql

> Migracion de la anterior base de datos a la nueva

	Folder Data
		Folder Migrations > Delete ALL

	Visua Studio
		Herramientas > Administrados de paquetes Nuget > Console del administrador de Paquetes: 
			Add-Migration MyAppInit

	Visual Studio Code
		Terminal en folder del proyecto
			dotnet tool install --global dotnet-ef
			dotnet ef migrations add MyAppInit

	Con esto se habra creado una nueva Migracion con los siguientes archivos:
		Folfer Data
			Folder Migrations
				.
				.
				.
		Folder Migrations
			20230321165743_MyAppInit.cs
			20230321165743_MyAppInit.Designer.cs
			ApplicationDbContextModelSnapshot.cs

	Una vez comprobada las tablas de la base de datos y sus atributos, lanzamos la migracion a nuestro mysql:
		dotnet ef database update

	Verificamos en localhost/phpmyadmin nuestras tablas

> Crear Modelos
	Primero Tablas bases
	Luego relaciones entre tablas
	Si es necesario, crear Tablas de rompimiento
	Si es necesario, crear listas enumeradas en la carpeta Enum

	Data folder
		Enum folder
			(aqui los archivos de numeracion)
		Migrations folder
		ApplicationDbContext.cs 
	Migrations folder
	Models folder
		(aqui los archivos de modelos, tablas y tablals de rompimiento)
		ErrorViewModel.cs

> Modificar:
	Folder Data
		Folder Enum
		Folder Migrations
		ApplicationDbContext.cs ( este archivo vamos a modificar)

> Migrar Nuevamente:
	Por Terminal:
		dotnet ef migrations add MyAppInitTwo
	Luego sale un nuevo archivo > ####(año)##(mes)##(dia)numeros_MyAppInitTwo.cs (example: 20230330215239_MyAppInitTwo.cs)
	Una vez verificado lo que vamos a migrar podemos subir estas nuevas tablas implementadas
	
	Por Terminal:
		dotnet ef database update

> Data
	AppDbInitializer.cs
	Ayadir una imagen:
		Terminal WSL Ubuntu/windows, navegar a donde esta la imagen desde ubuntu a windows
		y copiar a la carpeta de apache de Ubuntu:
			iniciar servidores:
				sudo service apache2 start
				sudo service mariadb start

			acceder a raiz:
				cd . > cd .. >	cd ~ 
				"El caso es llegar a la raiz de ubuntu y encontrar la carpeta mnt/ que nos permite acceder a los discos reales del computador"
			
			acceder a la parte donde quedo la imagen en nuestro equipo:
				ls > pwd > "se entra en mi caso a":
					/mnt/e/My PC/USTA/2023-1/ASP.NET/ProjectVisualStudio/ustaVideos/ustaVideosA/img
			La imagen adentro es: 
				mariobross.png
			crear directorio:
				sudo mkdir /var/www/html/images/
			copiar imagen de su origen a la carpeta deseada:
				 sudo cp /mnt/e/My\ PC/USTA/2023-1/ASP.NET/ProjectVisualStudio/ustaVideos/ustaVideosA/img/mariobross.png /var/www/html/images/
			acceder a localhost
				http://localhost/images/
			aqui se podran ver las imagenes que tenemos en la carpeta, al seleccionar uno tendremos:
				http://localhost/images/mariobross.png

> Program.cs

	var seeding = new AppDbInitializer();
	seeding.Seed(app);

	correr la aplicacion con los servidores ya iniciados:
		sudo service apache2 start
		sudo service mariadb start

		dotnet run

	En caso de que algun indice no empiece en cero:
		ALTER TABLE nombreTabla AUTO_INCREMENT = 0;

> Ahora si podemos iniciar a crear los controladores

> Luego de los controladores podemos verificar los datos y hacer cada una de las diferentes vistas
	En la carpeta de Vistas (Views) se creara una carpeta por cada uno de los ocntroladores que tenemos
	Dentro de cada una se creara e archivo Index.cshtml
	
> teniendo las vistas podemos hacer los cruds
	Details
	Edit
	Delete
	Validaciones: https://learn.microsoft.com/en-US/aspnet/core/mvc/models/validation?view=aspnetcore-7.0
	
> 

	

	