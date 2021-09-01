namespace MitoProducts.Entities
{
    public class Constants
    {
        public const string RouteTemplate = "api/v1/[controller]";
        public const string RouteTemplateSecure = "api/v1/[controller]/[action]";
        public const string V1 = "1.0";

        public const int Ok = 200;
        public const int Created = 201;
        public const int Accepted = 202;
        public const int NotFound = 404;
        public const int BadRequest = 400;
        public const int Unauthorized = 401;

        public const string Aceptado = "Aceptado";
        public const string Creado = "Creado";
        public const string Listo = "Ok";
        public const string Encontrado = "Encontrado";
        public const string NoEncontrado = "No Encontrado";
        public const string NoValido = "No Valido";
        public const string NoAutorizado = "No Autorizado";
    }
}
