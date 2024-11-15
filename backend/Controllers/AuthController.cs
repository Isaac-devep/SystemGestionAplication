using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace SystemGestionAplication.backend.Controllers
{
    public static class AuthController
    {
        private static readonly string SecretKey = Environment.GetEnvironmentVariable("JWT_SECRET_KEY") ?? throw new InvalidOperationException("JWT_SECRET_KEY no está configurada en las variables de entorno");

        // Simulación de base de datos de usuarios con roles
        private static readonly Dictionary<string, (string Password, string Role)> users = new()
        {
            { "nayibis", ("nayibis1703_", "admin") },
            { "gerente", ("geren2304*", "gerente") },
            { "supervisor_user", ("password123", "supervisor") },
            { "empleado_user", ("password123", "empleado") }
        };
        public static string Login(string username, string password)
        {
            // Validar el usuario y contraseña
            if (users.TryGetValue(username, out var userInfo) && userInfo.Password == password)
            {
                // Generar un token JWT con el rol del usuario
                return GenerateJwtToken(username, userInfo.Role);
            }
            else
            {
                return "Usuario o contraseña incorrectos"; // Usuario o contraseña incorrectos
            }
        }

        private static string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string? GetUserRole(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                // Extraer el rol del usuario
                var roleClaim = claimsPrincipal.FindFirst(ClaimTypes.Role);
                return roleClaim?.Value;
            }
            catch
            {
                return "Token invalido"; // Token inválido
            }
        }
    }
}
