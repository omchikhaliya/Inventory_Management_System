﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.ProductServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/IMS")]
    [System.SerializableAttribute()]
    public partial class Product : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductDescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductQuantityField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductDescription {
            get {
                return this.ProductDescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductDescriptionField, value) != true)) {
                    this.ProductDescriptionField = value;
                    this.RaisePropertyChanged("ProductDescription");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductId {
            get {
                return this.ProductIdField;
            }
            set {
                if ((this.ProductIdField.Equals(value) != true)) {
                    this.ProductIdField = value;
                    this.RaisePropertyChanged("ProductId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ProductName {
            get {
                return this.ProductNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductNameField, value) != true)) {
                    this.ProductNameField = value;
                    this.RaisePropertyChanged("ProductName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductPrice {
            get {
                return this.ProductPriceField;
            }
            set {
                if ((this.ProductPriceField.Equals(value) != true)) {
                    this.ProductPriceField = value;
                    this.RaisePropertyChanged("ProductPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductQuantity {
            get {
                return this.ProductQuantityField;
            }
            set {
                if ((this.ProductQuantityField.Equals(value) != true)) {
                    this.ProductQuantityField = value;
                    this.RaisePropertyChanged("ProductQuantity");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductService")]
    public interface IProductService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProducts", ReplyAction="http://tempuri.org/IProductService/GetProductsResponse")]
        System.Data.DataSet GetProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProducts", ReplyAction="http://tempuri.org/IProductService/GetProductsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductById", ReplyAction="http://tempuri.org/IProductService/GetProductByIdResponse")]
        Client.ProductServiceReference.Product GetProductById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetProductById", ReplyAction="http://tempuri.org/IProductService/GetProductByIdResponse")]
        System.Threading.Tasks.Task<Client.ProductServiceReference.Product> GetProductByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/AddProduct", ReplyAction="http://tempuri.org/IProductService/AddProductResponse")]
        string AddProduct(Client.ProductServiceReference.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/AddProduct", ReplyAction="http://tempuri.org/IProductService/AddProductResponse")]
        System.Threading.Tasks.Task<string> AddProductAsync(Client.ProductServiceReference.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProduct", ReplyAction="http://tempuri.org/IProductService/UpdateProductResponse")]
        string UpdateProduct(Client.ProductServiceReference.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/UpdateProduct", ReplyAction="http://tempuri.org/IProductService/UpdateProductResponse")]
        System.Threading.Tasks.Task<string> UpdateProductAsync(Client.ProductServiceReference.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/DeleteProduct", ReplyAction="http://tempuri.org/IProductService/DeleteProductResponse")]
        string DeleteProduct(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/DeleteProduct", ReplyAction="http://tempuri.org/IProductService/DeleteProductResponse")]
        System.Threading.Tasks.Task<string> DeleteProductAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/PurchaseProduct", ReplyAction="http://tempuri.org/IProductService/PurchaseProductResponse")]
        string PurchaseProduct(int id, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/PurchaseProduct", ReplyAction="http://tempuri.org/IProductService/PurchaseProductResponse")]
        System.Threading.Tasks.Task<string> PurchaseProductAsync(int id, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/SellProduct", ReplyAction="http://tempuri.org/IProductService/SellProductResponse")]
        string SellProduct(int id, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/SellProduct", ReplyAction="http://tempuri.org/IProductService/SellProductResponse")]
        System.Threading.Tasks.Task<string> SellProductAsync(int id, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetPurchasedProducts", ReplyAction="http://tempuri.org/IProductService/GetPurchasedProductsResponse")]
        System.Data.DataSet GetPurchasedProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetPurchasedProducts", ReplyAction="http://tempuri.org/IProductService/GetPurchasedProductsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetPurchasedProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetSoldProducts", ReplyAction="http://tempuri.org/IProductService/GetSoldProductsResponse")]
        System.Data.DataSet GetSoldProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductService/GetSoldProducts", ReplyAction="http://tempuri.org/IProductService/GetSoldProductsResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetSoldProductsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductServiceChannel : Client.ProductServiceReference.IProductService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductServiceClient : System.ServiceModel.ClientBase<Client.ProductServiceReference.IProductService>, Client.ProductServiceReference.IProductService {
        
        public ProductServiceClient() {
        }
        
        public ProductServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataSet GetProducts() {
            return base.Channel.GetProducts();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetProductsAsync() {
            return base.Channel.GetProductsAsync();
        }
        
        public Client.ProductServiceReference.Product GetProductById(int id) {
            return base.Channel.GetProductById(id);
        }
        
        public System.Threading.Tasks.Task<Client.ProductServiceReference.Product> GetProductByIdAsync(int id) {
            return base.Channel.GetProductByIdAsync(id);
        }
        
        public string AddProduct(Client.ProductServiceReference.Product p) {
            return base.Channel.AddProduct(p);
        }
        
        public System.Threading.Tasks.Task<string> AddProductAsync(Client.ProductServiceReference.Product p) {
            return base.Channel.AddProductAsync(p);
        }
        
        public string UpdateProduct(Client.ProductServiceReference.Product p) {
            return base.Channel.UpdateProduct(p);
        }
        
        public System.Threading.Tasks.Task<string> UpdateProductAsync(Client.ProductServiceReference.Product p) {
            return base.Channel.UpdateProductAsync(p);
        }
        
        public string DeleteProduct(int id) {
            return base.Channel.DeleteProduct(id);
        }
        
        public System.Threading.Tasks.Task<string> DeleteProductAsync(int id) {
            return base.Channel.DeleteProductAsync(id);
        }
        
        public string PurchaseProduct(int id, int quantity) {
            return base.Channel.PurchaseProduct(id, quantity);
        }
        
        public System.Threading.Tasks.Task<string> PurchaseProductAsync(int id, int quantity) {
            return base.Channel.PurchaseProductAsync(id, quantity);
        }
        
        public string SellProduct(int id, int quantity) {
            return base.Channel.SellProduct(id, quantity);
        }
        
        public System.Threading.Tasks.Task<string> SellProductAsync(int id, int quantity) {
            return base.Channel.SellProductAsync(id, quantity);
        }
        
        public System.Data.DataSet GetPurchasedProducts() {
            return base.Channel.GetPurchasedProducts();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetPurchasedProductsAsync() {
            return base.Channel.GetPurchasedProductsAsync();
        }
        
        public System.Data.DataSet GetSoldProducts() {
            return base.Channel.GetSoldProducts();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetSoldProductsAsync() {
            return base.Channel.GetSoldProductsAsync();
        }
    }
}
