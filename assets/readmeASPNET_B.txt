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
	(bases de datos > crear base de datos)

	nombre: db_ruisoArtPage
			utf8mb4_general_ci

			CREAR

	(bases de datos, seleccionar base de datos, privilegios, agregar cuenta de usuario)

	privilegios:
		agregar cuenta de usuario
			nombre: usr_admin_ruiso
			host: %
			contraseña: 159951#ustaFN
			authentication plugin: authentication de MySQL nativo

		bases de datos para la cuenta de usuario

			base de datos para la cuenta de usuario: otorgar todos los privilegios para la base de datos db_....

		privilegios glovales

				Datos: all
				Estructuras : all
				Administracion: all
				SSL: require none

			

> appsettings.json:
	{
		"ConnectionStrings": {
			"DefaultConnection": "Server=localhost; Database=db_ruisoArtPage; Uid=usr_admin_ruiso; Pwd=159951#ustaFN;"
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

	dentro de la ruta de aplicacion:
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

"dotnet add package Pomelo.EntityFrameworkCore.MySql -v 6.0.0" este comando es para instalar el driver de mariadb/mysql (Solo si es necesario para un proyecto que se este haciendo en SDKNET6, en este caso yo no, porque lo estoy haciendo en SDK.NET.v7)

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

	Para quitar la restriccion de valores nulos:
		Se puede o poner el campo de esta manera:
			public string Bio {get; set;} >>> public string? Bio {get; set;}
		O se pude modificar las restricciones del proyecto:
			(ustaVideos.csproj)
				<Nullable>enable</Nullable>
						cambio a:
				<Nullable>disable</Nullable>

	Para las relationships

		ONE TO MANY: public List<Algo> Algos { get; set; }
		MANY TO ONE: 	public int AlgoId { get; set; }
				        [ForeignKey("AlgoId")]
				        public Algo Algo { get; set; }

				        utilizadas en tablas de rompimiento

	Ahora si hechos los modelos con sus respectivas relaciones, podemos actualizar la base de datos. Pero antes de eso debemos recordar que debemos decirle que tablas deseamos migrar como tal. Esto se hace especificando un contexto dentro de nuestro archivo AplicationDbContext.cs antes de realizar la nueva migracion.

> Modificar:
	Folder Data
		Folder Enum
		Folder Migrations
		ApplicationDbContext.cs ( este archivo vamos a modificar)
			Aqui vamos a especificar las tablas que vamos amigrar a nuestra base de datos.
			Todas las tablas, incluyendo las de rompimiento.

> Migrar Nuevamente:
	Por Terminal:
		dotnet ef migrations add MyAppInitTwo
	Luego sale un nuevo archivo > ####(año)##(mes)##(dia)numeros_MyAppInitTwo.cs (example: 20230330215239_MyAppInitTwo.cs)
	Una vez verificado lo que vamos a migrar podemos subir estas nuevas tablas implementadas
	
	Por Terminal:
		dotnet ef database update

> Vamos agregar data inicial para nuestra base de datos, datos por defecto con los podemos arrancar la base de datos, para esto podemos crear en data un nuevo archivo que se llame AppInitializer.cs con la data que necesitamos por CADA tabla de nuestra base de datos y a continuacion modificar nuestro Program.cs para que arranque nuestro proyecto con esta data inicial.

	Data
		AppDbInitializer.cs (aqui vamos a modificar contextos inciales de nuestra base de datos)

	(Vamos a tener que agregar imagenes, por lo que podemos agregarlas de la siguiente manera)
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

	(Una vez terminados los contextos con los que inicia la base de datos, debemos agregarlos a Program .cs para que arranquen con el proyecto)

	Program.cs

		var seeding = new AppDbInitializer();
		seeding.Seed(app);

		correr la aplicacion con los servidores ya iniciados:
			sudo service apache2 start
			sudo service mariadb start

			dotnet run

		En caso de que algun indice no empiece en cero:
			ALTER TABLE nombreTabla AUTO_INCREMENT = 0;

> Ahora si podemos iniciar a crear los controladores
	(Todo lo que observamos o cualquier peticion que hagamos desde una Vista, relamente lo hacemos a los ocntroladores del sistema. se acostumbra hacer un controlador por cada tabla que tenemos salvo las de rompimiento para indicar una serie de acciones o peticioines propias de cada tabla, asi no todas tengan una vista personal)


> Luego de los controladores (o a la vez que se desarrollan) podemos verificar los datos y hacer cada una de las diferentes vistas
	En la carpeta de Vistas (Views) se creara una carpeta por cada uno de los ocntroladores que tenemos
	Dentro de cada una se creara e archivo Index.cshtml
	
> teniendo las vistas podemos hacer los cruds
	Details
	Edit
	Delete
	Validaciones: https://learn.microsoft.com/en-US/aspnet/core/mvc/models/validation?view=aspnetcore-7.0
	
> Teniendo los cruds de edicion podemos hacer el crud de CREATE

> una ves terminados los cruds podemos arreglar nuestras paginar por defecto par cuando no se encuentra el ID o data especificada. Para esto debemos modificar el controllador d enuestro intenteres en cada una d elas operaciones IOActionResult que sean necesarias para votar a a vista de NotFound, a continuacion creamos nuestra vista NotFound.cshtml pero en vez de la carpeta de vistas que estamos utlizando, esta sera una vista general que usar en todo el proyecto, por lo tanto ira en Shared. Algo como lo siguiente puede bastar en esa vista:

		<div class="row">
		    <div class="col-md-12 offset-0">
		        <h3 class="text-info">This item was not found!</h3>
		        <hr />
		        <img style="width:100%" src="https://images.unsplash.com/photo-1633078654544-61b3455b9161?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1045&q=80"/>
		        <hr />
		        <a class="btn btn-outline-success" asp-controller="Home" asp-action="Index">Home</a>
		    </div>
		</div>

> Luego de hacer esto, para mejorar la interaccion por parte del administrador al momento de revisar cada vista de las que hemos hecho, podemos hilar todo en un menu desplegable con cada CRUD. Para eso nos dirigimos a el archivo:

	Shared ( folder )
		_Layout.cshtml

Y modificamos el codigo en la seccion de NAVBAR para agregar un menu DROPDOWN.

> Debido a que podemos tener mucha informacion en cada vista, se nos es necesario crear una paginacion de nuestros productos o items, esto se logra modificando, los Index de los archivos controller:

	Controllers ( folder )
		archivos Controller .cs

	(Antes de esto debemos instalar los paquetes Nuget de X.pagedList)

	https://www.nuget.org/packages/X.PagedList/
		dotnet add package X.PagedList --version 8.4.7 
	https://www.nuget.org/packages/X.PagedList.Mvc.Core
		dotnet add package X.PagedList.Mvc.Core --version 8.4.7
	https://www.nuget.org/packages/X.PagedList.Web.Common
		dotnet add package X.PagedList.Web.Common --version 8.0.7


	Luego de la modificacion de la consulta del Index, se modifica su .cshtml correspondiente.


	Como ya podemos intuir, podemos utilizar la paginacion en toda aquella vista que necesite de la misma. Listados de Items

> si ya nuestras paginaciones estan correctas en cada Vistas y estas no tienen errores visuales o de funcionamiento, podemos alterar nuestra vista Vitrina para que en vez de ser una tabla de edicion, ser una en tipo de Cards. Luego testeamos el correcto funcionamiento de los Cruds.

En caso de que sea necesario transformar nuevamente la Base de datos, podemos modificar en orden:
	Database
	Models
	ApplicationDbContext
	AppDbInitializer
	_Layout.cshtml
	(otros modelos con los que se tenian relaciones)
	Controller
	(controllers donde se tenian relaciones)
	Vistas
	(other views donde se tenian relaciones)

	(archivos varios anexados)

	Migrar Nuevamente:
		Por Terminal:
			dotnet ef migrations add MyAppInitTwo
		
		Por Terminal:
			dotnet ef database update

> Si lo considera necesario puede cambiar la ruta de carga por defecto de la aplicacion en:

	Properties
		launchSettings.json (modificar)

	"http": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl":"Product",
      "applicationUrl": "http://localhost:5113",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "https": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl":"Product",
      "applicationUrl": "https://localhost:7048;http://localhost:5113",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }


> Una vez con el funcionamiento e nuestra aplicacion, podemos realizar ajuste de Authorization y Authentication
	
	Models
		ApplicationUser.cs (crear)

	Data
		ApplicationDbcontext.cs (modificar)

	Data > Static
		UserRoles.cs (crear)

	Data
		AppDbInitializer.cs (modificar)

	Program.cs (modificar)

	_LoginPartial.cshtml (modificar)

	Migrar Nuevamente:
		Por Terminal:
			dotnet ef migrations add MyAppInitTwo
		
		Por Terminal:
			dotnet ef database update


> Acceder a los Login y Register

	(https://learn.microsoft.com/es-es/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-7.0&tabs=netcore-cli)

	Aplicar scaffolding Identity a un Razor proyecto sin autorización existente

			dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

		Si no ha instalado previamente el scaffolder de ASP.NET Core, instálelo ahora:

			dotnet tool install -g dotnet-aspnet-codegenerator

		Si no ha instalado previamente el scaffolder de ASP.NET Core, instálelo ahora:

			dotnet tool install -g dotnet-aspnet-codegenerator

		Agregue las referencias de paquete NuGet necesarias al archivo de proyecto (.csproj). Ejecute los siguientes comandos en el directorio del proyecto:

			dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
			dotnet add package Microsoft.EntityFrameworkCore.Design
			dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
			dotnet add package Microsoft.AspNetCore.Identity.UI
			dotnet add package Microsoft.EntityFrameworkCore.SqlServer
			dotnet add package Microsoft.EntityFrameworkCore.Tools

		Ejecute el siguiente comando para enumerar las Identity opciones de scaffolder:

			dotnet aspnet-codegenerator identity -h

			output terminal:{
				Usage: aspnet-codegenerator [arguments] [options]

				Arguments:
				  generator  Name of the generator. Check available generators below.

				Options:
				  -p|--project             Path to .csproj file in the project.
				  -n|--nuget-package-dir
				  -c|--configuration       Configuration for the project (Possible values: Debug/ Release)
				  -tfm|--target-framework  Target Framework to use. (Short folder name of the tfm. eg. net46)
				  -b|--build-base-path
				  --no-build

				Selected Code Generator: identity

				Generator Options:
				  --dbContext|-dc                : Name of the DbContext to use, or generate (if it does not exist).
				  --files|-fi                    : List of semicolon separated files to scaffold. Use the --listFiles option to see the available options.
				  --listFiles|-lf                : Lists the files that can be scaffolded by using the '--files' option.
				  --userClass|-u                 : Name of the User class to generate.
				  --databaseProvider|-dbProvider : Database provider to use. Options include 'sqlserver' (default), 'sqlite', 'cosmos', 'postgres'.
				  --force|-f                     : Use this option to overwrite existing files.
				  --useDefaultUI|-udui           : Use this option to setup identity and to use Default UI.
				  --layout|-l                    : Specify a custom layout file to use.
				  --generateLayout|-gl           : Use this option to generate a new _Layout.cshtml
				  --bootstrapVersion|-b          : Specify the bootstrap version. Valid values: '3', '4'. Default is 4.
				  --useSqLite|-sqlite            : Flag to specify if DbContext should use SQLite instead of SQL Server.
			}


		En la carpeta del proyecto, ejecute el Identity scaffolder con las opciones que desee. Por ejemplo, para configurar la identidad con la interfaz de usuario predeterminada y el número mínimo de archivos, ejecute el siguiente comando:

			dotnet aspnet-codegenerator identity --useDefaultUI

			dotnet aspnet-codegenerator identity -dc MyApplication.Data.ApplicationDbContext --files "Account.Register;Account.Login"

> Adecuar 

	Areas > Identity > Pages > Account

		Login.cshtml (modificar al gusto)
		Login.cshtml.cs (modificar en caso de tener Identity User pasar a ApplicationUser)

	Program.cs (se habra modificado tras el Scalfoding asi que se comentarea la linea)
		builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

> Authenticacion

	Cambiar loc ontroladores con las etiquetas EDIT, DELETE, CREATE

		[Authorize(Roles = UserRoles.Admin)]

	_Layout.cshtml (agregar la autthorizacion de usuario)

	Para comprar se tiene que tener usuario

>