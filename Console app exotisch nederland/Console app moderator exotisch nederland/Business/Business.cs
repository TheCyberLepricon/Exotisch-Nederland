using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console_app_moderator_exotisch_nederland.Data;
using Console_app_moderator_exotisch_nederland.Presentation;

namespace Console_app_moderator_exotisch_nederland.Business
{
    internal class BusinessProgram
    {
        DataProgram _data = new DataProgram();
        


        //public DateTime DateTimeConvertToString(string DatumTijdDB)
        //{

            

        //}

        public int AantalTempRegistraties()
        {
            int AantalRegistraties = _data.HaalTussenDatabaseOp().Count();
            return AantalRegistraties;
        }
    }
}
