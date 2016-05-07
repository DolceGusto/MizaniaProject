using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Practices.Unity;
using MizaniaServices;
using IOC;
using MizaniaData.Data;

namespace MizaniaSilProjet.Controllers
{
    public class TransactionController : ApiController
    {
        private ITransactionService _transactionService;


        public TransactionController()
        {
            _transactionService = IoC_Config.Container.Resolve<ITransactionService>();
        }

        [HttpGet] /* Retourne tous les utilisateurs */
        public List<Transactions> getAllTransactions()
        {
            return _transactionService.GetAllTransactions().ToList();
        }

        [HttpGet] 
        public List<Transactions> getAllTransactionsEntrees()
        {
            return _transactionService.FindTransactionsEntree().ToList();
        }

        [HttpGet]
        public double getTotalDepenses()
        {
            return _transactionService.totalDepenses();
        }

        [HttpGet]
        public double getTotalRevenus()
        {
            return _transactionService.totalRevenus();
        }

        [HttpGet] 
        public List<Transactions> getAllTransactionsDepenses()
        {
            return _transactionService.FindTransactionsDepense().ToList();
        }

        [HttpGet]
        public string getNomCategorie(int id, int idCompte)
        {
            return _transactionService.nomCatgorieTransaction(id,idCompte) ;
        }
        [HttpGet]
        public Transactions getOneTransaction(int id, int idCompte)
        {
            return _transactionService.GetTransactionById(id, idCompte);
        }


        [HttpPost]  /*Permet d'ajouter un utilisateur */
        public HttpResponseMessage addTransaction([FromBody]Transactions transaction)
        {

            try
            {
                if (!_transactionService.CreateTransaction(transaction))
                {
                    throw new Exception("ajout de l'instance de transaction non effecuté ");
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);
                response.StatusCode = HttpStatusCode.Created;
                String uri = Url.Link("GetTransaction", new { id = transaction.id });
                response.Headers.Location = new Uri(uri);

                return response;

            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }

        }



        [HttpDelete]
        public HttpResponseMessage deleteTransaction(int id, int idCompte)
        {
            try
            {
                if (!_transactionService.DeleteTransaction(id, idCompte))
                {
                    throw new Exception(" Impossible de supprimer de la transaction dont ID = " + id);
                }
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);

                return response;
            }
            catch (Exception e)
            {
                HttpResponseMessage response;
                response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage updateTransaction(Transactions transac)
        {
            try
            {

                if (!_transactionService.UpdateTransaction(transac))
                {

                    throw new Exception("Mise à jour de l'utilisateur échouée");
                }
                Transactions transaction = _transactionService.GetTransactionById(transac.id, transac.idCompte);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, transaction);
                response.StatusCode = HttpStatusCode.OK;
                String uri = Url.Link("GetTransaction", new { id = transaction.id, idCompte = transaction.idCompte });
                response.Headers.Location = new Uri(uri);

                return response;


            }
            catch (Exception e)
            {
                HttpResponseMessage response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);

                return response;
            }
        }
    }
}