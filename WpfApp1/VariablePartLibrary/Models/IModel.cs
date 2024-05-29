using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablePartLibrary.Models
{
    public interface IModel
    {

        List<IModel> GenerateData();

    }
}
