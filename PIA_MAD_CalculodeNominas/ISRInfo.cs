using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD_CalculodeNominas
{
    // Esta clase solo sirve para almacenar los datos de un renglón de la tabla ISR
    public class RenglonISR
    {
        public decimal LimiteInferior { get; set; }
        public decimal CuotaFija { get; set; }
        public decimal PorcentajeSobreExcedente { get; set; }
    }
}