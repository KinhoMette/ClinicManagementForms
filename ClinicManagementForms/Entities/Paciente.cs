using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementForms.Entities
{
    public class Paciente
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string ContatoTelefonico { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
    }
}