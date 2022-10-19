A. Instrucciones de cómo ejecutar la aplicación en un ambiente local con Docker Windows o Linux.

	1-) Instalar Docker Desktop con motor Linux activando virtualizacion (Windows) o instalarlo desde lineas de 
            comandos en Linux "sudo apt install docker-ce" mas detalle aca: https://www.hostinger.co/tutoriales/como-instalar-y-usar-docker-en-ubuntu.
	2-) Instalar ASP NET Core Runtime y SDK 5.0 para efecto de Desarrollo y compilacion en el IDE.
	3-) Contar con un IDE Visual Studio Comunity 2022 o superior o tambien Visual Studio Code (Si estas en Linux).
	4-) Activar o iniciar el Docker Desktop en Windows o servicio de Docker en Linux.
	5-) Abrir la solucion Docker-Compose en el IDE VS mediante el archivo ./BlueBank.Banco-FE/Bluebank.Banco.sln.
	6-) Correr las Pruebas Unitarias en el IDE o con dotnet test para ver si todo esta bien en el codigo.
	7-) Limpiar la Solucion 
	8-) Compilar la solucion con Docker-Compose o con esta linea comando ubicado en el mismo directorio donde esta el 
            archivo de orquestacion docker-compose.yml:
	        
                Modo VS Code:
		Abrir una terminal o Shell Windows o Linux y entrar dentro del Proyecto del BlueBank.Banco-FE/
                
                Ejecutar: docker-compose build

		Modo VS 2022 IDE:

		Ejecutar el Compiler de la Solucion en modo Docker-Compose Build


		(Esto descargara las imagenes bases requeridas, paquetes y runtime para Dotnet 5.0, Nginx y MsSQLServer para 
                los servicios, demora un poco y pesan algo. Tambien ejecutara las pruebas Unitarias y si pasan todas generara
		la imagen del servicio Api Rest que esta probando)

	
	9-) Correr solo el Test con Docker-Compose con esta linea comando ubicado en el mismo directorio donde esta el 
            archivo de orquestacion docker-compose.yml:
	        
                Terminar PS o Linux:
		Abrir una terminal o Shell Windows o Linux y entrar dentro del Proyecto del BlueBank.Banco-FE/
                
                Ejecutar: docker-compose run bluebank.banca.services.webapi.test

		(Esto correra las pruebas unitarias del proyecto xUnit de la solucion que prueba los componentes del Backend
                y dejara las evidencias XML de resultados en el directrio ./BlueBank.Banco-FE/test/tests-results/)

	10-) Correr la solucion con Docker-Compose o con esta linea comando ubicado en el mismo directorio donde esta el 
            archivo de orquestacion docker-compose.yml:
	        
                Modo VS Code:
		Abrir una terminal o Shell Windows o Linux y entrar dentro del Proyecto del BlueBank.Banco-FE/
                
                Ejecutar: docker-compose up -d

		Modo VS 2022 IDE:

		Ejecutar el RUN de la Solucion en modo Docker-Compose |>>


		(Esto levantara las imagenes creadas en sus contenedores respectivos)
		
	11-) Observar en el Docker Desktop los Contenedores levantados en sus respectivos puertos e IP y probar en un navegador
	     web el Backend por: http://localhost:5000/swagger/index.html, el Frontend por: http://localhost:4200 y la BD por
	     un tool SSMS u otro como HeidiSQL o por lineas de comando sqlserve a traves de esta cadena de conexion:	
	     "Server=tcp:127.0.0.1,5433;Database=BlueBank;User ID=sa;Password=Pass@word"

             Consultar todos los contenedores creados por lineas de comando PS o Linux:

	     Ejecutar: docker ps -a


	     Consultar todas las imagenes creadas por lineas de comando PS o Linux:

	     Ejecutar: docker images -a

	    
             Consultar todos los volumenes creados por lineas de comando PS o Linux:

	     Ejecutar: docker volume ls

			
	12-) Detener la solucion con Docker-Compose o con esta linea comando ubicado en el mismo directorio donde esta el 
            archivo de orquestacion docker-compose.yml:
	        
                Modo VS Code:
		Abrir una terminal o Shell Windows o Linux y entrar dentro del Proyecto del BlueBank.Banco-FE/
                
                Ejecutar: docker-compose stop

		Modo VS 2022 IDE:

		Ejecutar el Stop de la Solucion en modo Docker-Compose []


		(Esto detendra los contenedores y los dejara en Exits)

	13-) Eliminar todo los contedores detenidos, imagenes y volumen para limpiar el disco duro atravez de lineas de comandos.

             Eliminar todos los contenedores detenidos

	     	Ejecutar: docker system prune


	     Eliminar todas las imágenes

                Ejecutar: docker rmi $(docker images -a -q)


             Eliminar todos los volumenes

		Ejecutar: docker volume prune


             Tambien se puede eliminar en el entorno Visual de Docker Desktop.

Secret Revelado: gZC6rMQypQ2MxLpNbsox
## GitLab Flow con CI/CD.

Comandos Kubectl y Minikube

minikube docker-env

Pod:
kubectl run bluebankfront --image=pm44019/bluebankbancafe:v3 --port=81 --env="VAR_BD=123"

Service:
kubectl expose pod bluebankfront --type=LoadBalancer --port=4200 --target-port=81

Deployment:
kubectl apply -f ./