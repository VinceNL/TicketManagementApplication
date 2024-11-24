using System.Text;
using System.Text.Json;
using Jose;

namespace UI.Security
{
    public class EncryptionHelper<T> where T : class
    {
        private byte[] secretKey;
        private readonly IConfiguration _configuration;

        public EncryptionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            secretKey = Encoding.UTF8.GetBytes(_configuration["JWEKey"]!);
        }

        public string Encode(object obj)
        {
            return JWT.Encode(obj, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
        }

        public T Decode(string token)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var result = JWT.Decode(token, secretKey, JweAlgorithm.A256KW, JweEncryption.A256CBC_HS512);
            return JsonSerializer.Deserialize<T>(result, options) ?? throw new InvalidOperationException("Deserialization returned null");
        }
    }
}
