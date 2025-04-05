using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.projectCholcaByron.common.Dto
{
    public class ClienteDto
    {
        public int Id  { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Email { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string? CedulaIdentidad { get; set; }
    }
}
