using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ServiceModel;

namespace IMS
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        DataSet GetProducts();

        [OperationContract]
        Product GetProductById(int id);

        [OperationContract]
        string AddProduct(Product p);

        [OperationContract]
        string UpdateProduct(Product p);

        [OperationContract]
        string DeleteProduct(int id);

        [OperationContract]
        string PurchaseProduct(int id, int quantity);

        [OperationContract]
        string SellProduct(int id, int quantity);

        [OperationContract]
        DataSet GetPurchasedProducts();

        [OperationContract]
        DataSet GetSoldProducts();
    }
}
