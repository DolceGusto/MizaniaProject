using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MizaniaData.IGenericRepository;
using MizaniaData.Data; 


namespace MizaniaServices
{
    public interface ICategorieService
    {
        Categorie GetCategorieById(int CategoryId);
        IEnumerable<Categorie> GetAllCategories();
        bool AddCategorie(Categorie categorie);
        bool DeleteCategorie(int id);
        bool UpdateCategorie(Categorie categorie);
        
    }
}
