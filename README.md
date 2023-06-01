# ProductsAPI
API para administrar productos básicos de una tienda.
Para usar el API, por favor solicitamos tener en cuenta los siguientes aspectos: 

1. Conexión:
En el archivo appsettings.json se encuentran las propiedades de conexión a la BD SQL Server. En la cadena de conexión "CatalogConnection" por favor ajustar las propiedades según corresponda: 
Server: servidor de base de datos SQL Server
  - Database: base de datos SQL Server, esta puede o no estar creada
  - User Id: usuario de SQL Server, tener precaución de que cuente con permisos de creación de BD
  - Password: contraseña de usuario de SQL Server

Esto dará como resultado una cadena similar a esta:
  "Server={Servidor SQL Server};Database={Nombre de la BD};User Id = {Usuario de SQL Server}; Password = {Contraseña de SQL Server; Integrated Security = False; Encrypt=False"
2. Despliegue
Una vez configurada la cadena de conexión, ejecute el proyecto en VS 2022. Antes de desplegar el API, el proceso creará la BD en el servidor.
3. Uso 
El API ProductsAPI tiene 4 endpoints:
 - Products [GET]: consultar los productos creados
 - Products [PUT]: modificar un producto
 - Products [POST]: crear un producto
 - Products [DELETE]: eliminar un producto. 

A continuación se indica cómo usar cada endpoint: 
**Products [GET]:** este endpoint requiere de los siguientes parámetros:
 - page (int, mandatory): 0 si no se quiere paginación, 1 o más dependiendo el número de página.
 - pageSize (int, mandatory): 0 si no se quiere paginación, 1 o más para especificar el tamaño de la página. 
 - filter (string, optional): especificar valor del filtro
 - filterType (int, optional): filtro por los diferentes campos así: 1 = nombre; 2 = descripción; 3 = categoría. Si no se especifica, será 0.
 - orderBy (string, optional): concatenado de ordenado, así: [tipoFiltro,asc|desc]. Ejemplo, para filtrar por nombre ascendente será así: 1,asc
**Products [PUT]**: este endpoint requiere de los siguientes parámetros:
 - Id (int, mandatory): id del producto a modificar
 - Nombre (string, mandatory): nombre del producto a modificar
 - Descripcion (string, mandatory): descripción del producto a modificar
 - Categoria (string, mandatory): categoría del producto a modificar
 - URLImagen (string, mandatory): url de imagen del producto a modificar
**Products [POST]**: este endpoint requiere de los siguientes parámetros:
este endpoint requiere de los siguientes parámetros:
 - Nombre (string, mandatory): nombre del producto a crear
 - Descripcion (string, mandatory): descripción del producto a crear
 - Categoria (string, mandatory): categoría del producto a crear
 - URLImagen (string, mandatory): url de imagen del producto a crear
 **Products [GET]:** este endpoint requiere del siguiente parámetro:
 - Id (int, mandatory): id del producto a eliminar

En caso de que los productos a modificar o eliminar no se encuentren en la base de datos, se retornará un BadRequest porque el producto no existe.
 
