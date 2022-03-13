# API Clima

_Este proyecto consta de una API que simula el comportamiento de un servicio de clima en tiempo real, en el que se puede consultar dos endpoints que devolverán el clima actual
de una ciudad específica y el pronóstico a cinco dias de una ciudad específica._ 
_Además es posible consultar los paises y ciudades disponibles.
Este proyecto consta de dos contenedores, uno para la API y otro para la base de datos. Gracias a esto no es necesario el uso de ningún script para la creación 
de la base de datos. Esta es creada, configurada y populada automáticamente al iniciar los contenedores._

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Contenido</summary>
  <ol>
    <li>
      <a href="#comenzando-">Comenzando</a>
      <ul>
        <li><a href="#pre-requisitos-">Pre-requisitos</a></li>
      </ul>
        <ul>
        <li><a href="#instalación-y-ejecución-">Instalación y ejecución</a></li>
      </ul>
    </li>
    <li><a href="#capturas-">Capturas</a></li>
    <li><a href="#construido-con-%EF%B8%8F">Construido con</a></li>
    <li><a href="#contacto-">Contacto</a></li>
  </ol>
</details>

## Comenzando 🚀

### Pre-requisitos 📋

_Para ejecutar este proyecto es necesario contar con [Docker](https://docs.docker.com/desktop/windows/install/)_

### Instalación y ejecución 🔧

1. Clonar el repositorio
   ```sh
   git clone https://github.com/sosajseba/weather-api.git
   ```
2. Build
   ```sh
   docker-compose build
   ```
   _Este paso puede demorar varios minutos dependiendo de la velocidad de su conexión_
3. Ejecutar
   ```sh
   docker-compose up
   ```
4. En su navegador acceder a `http://localhost:8080/swagger/index.html`
5. Para acceder al archivo de log en otra terminal ejecutar los comandos
   ```sh
   docker exec -t -i weather-api-web-1 /bin/sh
   
   ```
   Acceder a la carpeta de logs
   ```sh
   cd Logs/
   
   ```
   Leer archivo (nombre variable según fecha) 
   ```sh
   cat webapi-20220313.log
   ```   

## Capturas 📷

![swagg](https://user-images.githubusercontent.com/20545122/158082503-8dfbe61b-479d-4144-8df8-de5ea8e1c837.PNG)

## Construido con 🛠️

* [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* [EntityFrameworkCore](https://entityframeworkcore.com/)
* [SQL Server 2019](https://www.microsoft.com/es-es/sql-server/sql-server-2019)
* [Serilog](https://serilog.net/)
* [Swagger](https://swagger.io/)
* [Docker](https://www.docker.com/)

## Contacto

* **Juan Sebastian Sosa** - [Linkedin](https://www.linkedin.com/in/juansebastiansosa/)

<p align="right">(<a href="#top">Volver arriba</a>)</p>
