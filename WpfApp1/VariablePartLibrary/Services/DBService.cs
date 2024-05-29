using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariablePartLibrary.Models;

namespace VariablePartLibrary.Services
{
    public class DBService
    {
        private static DBService _instance;

        public static DBService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DBService();
                return _instance;
            }
        }

        private readonly Dictionary<Type, List<IModel>> _modelsData = new Dictionary<Type, List<IModel>>();

        private DBService()
        {
            InitData();
        }

        public List<T> GetModelData<T>() 
        {
            if (_modelsData.ContainsKey(typeof(T)))
                return _modelsData[typeof(T)].Cast<T>().ToList();
            return null;
        }

        public void AddItem<T>(T item)
        {
            var data = GetModelData<T>();
            data.Add(item);
        }

        public void RemoveItem<T>(T item)
        {
            var data = GetModelData<T>();
            data.Remove(item);
        }

        private void RegisterModel(IModel model)
        {
            _modelsData.Add(model.GetType(), model.GenerateData());
        }

        private void InitData()
        {
            RegisterModel(new PlantType());
            RegisterModel(new Plant());
        } 

    }
}
