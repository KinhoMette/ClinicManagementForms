using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementForms.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
    }
}