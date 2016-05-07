using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MizaniaData.IGenericRepository;
using MizaniaData.Data; 

namespace MizaniaServices
{
    public class CategorieService : ICategorieService
    {
       
        private IGenericRepository<Categorie> _categorieRepository;

       public CategorieService(IGenericRepository<Categorie> categorieRepository)
       {
           this._categorieRepository = categorieRepository; 
       }

       public IEnumerable<Categorie> GetAllCategories()
       {
           return _categorieRepository.GetAll(); 
       }

       public Categorie GetCategorieById(int CategorieId)
       {
           return _categorieRepository.GetByID(CategorieId);
       }
        
       public bool AddCategorie (Categorie categorie)
       {
           if (_categorieRepository.Insert(categorie))
               return true; 
           else return false; 
           
        }

        public bool DeleteCategorie(int id)
       {
           if (_categorieRepository.Delete(id))
               return true;
           else return false; 
       }

        public bool UpdateCategorie(Categorie categorie)
        {
            if (_categorieRepository.Update(categorie))
                return true;
            else return false; 
        }

    }
}