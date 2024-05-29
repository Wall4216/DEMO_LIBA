using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariablePartLibrary.Models
{
    public class PlantType : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public PlantType()
        {

        }

        public PlantType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public List<IModel> GenerateData()
        {
            return new List<IModel>() { new PlantType(1, "Дерево"),
                                        new PlantType(2, "Кустарник"),
                                        new PlantType(3, "Трава") };
        }

    }
}
