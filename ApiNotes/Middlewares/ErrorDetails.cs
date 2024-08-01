using System.Text.Json;

namespace ApiNotes.Middlewares
{
    public class ErrorDetails
    {

        //Representa o código de status Http associado ao erro
        public int StatusCode { get; set; }
        //Armazena uma mensagem 
        public string? Message { get; set; }
        public string? Trace { get; set; }
        //Serialiazndo O ERROR details no formato Json
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
