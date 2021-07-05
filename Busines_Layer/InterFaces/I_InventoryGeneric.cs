using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines_Layer.InterFaces
{
    public interface I_InventoryGeneric<Type>
    {
        public List<Type> GetAllData();
        public Type GetById(int id);
        public void Creat(Type obj);
        public void Update(Type obj);
        public void Delete(string id);
        public Type MyLastId();

    }
}
