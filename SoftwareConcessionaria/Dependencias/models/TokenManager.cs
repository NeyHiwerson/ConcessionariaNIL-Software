using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConcessionaria.Dependencias.models
{
    public class TokenManager
    {
        public string type;
        public string token;

        // Construtor vazio
        public TokenManager()
        {
            type = null;
            token = null;
        }

        // Método para verificar se o token está disponível
        public bool IsTokenAvailable()
        {
            return !string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(token);
        }

        // Método para atualizar o token
        public void UpdateToken(string accessToken, string tokenType)
        {
            type = accessToken;
            token = tokenType;
        }

        // Método para limpar o token
        public void ClearToken()
        {
            type = null;
            token = null;
        }
    }

}
