/* 
 * TomiSoft Product Database Api
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: 1.0
 * 
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client;
using TomiSoft.ProductCatalog.Client.OpenApiGenerated.Model;

namespace TomiSoft.ProductCatalog.Client.OpenApiGenerated.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProductApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a product by barcode
        /// </remarks>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>ProductInformationDto</returns>
        ProductInformationDto GetByBarcode (string barcode);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a product by barcode
        /// </remarks>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>ApiResponse of ProductInformationDto</returns>
        ApiResponse<ProductInformationDto> GetByBarcodeWithHttpInfo (string barcode);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProductApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a product by barcode
        /// </remarks>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>Task of ProductInformationDto</returns>
        System.Threading.Tasks.Task<ProductInformationDto> GetByBarcodeAsync (string barcode);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Gets a product by barcode
        /// </remarks>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>Task of ApiResponse (ProductInformationDto)</returns>
        System.Threading.Tasks.Task<ApiResponse<ProductInformationDto>> GetByBarcodeAsyncWithHttpInfo (string barcode);
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IProductApi : IProductApiSync, IProductApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class ProductApi : IProductApi
    {
        private TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProductApi() : this((string) null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ProductApi(String basePath)
        {
            this.Configuration = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration.MergeConfigurations(
                TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.GlobalConfiguration.Instance,
                new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration { BasePath = basePath }
            );
            this.Client = new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public ProductApi(TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration.MergeConfigurations(
                TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public ProductApi(TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ISynchronousClient client,TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.IAsynchronousClient asyncClient, TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.IReadableConfiguration configuration)
        {
            if(client == null) throw new ArgumentNullException("client");
            if(asyncClient == null) throw new ArgumentNullException("asyncClient");
            if(configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.IReadableConfiguration Configuration {get; set;}

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        ///  Gets a product by barcode
        /// </summary>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>ProductInformationDto</returns>
        public ProductInformationDto GetByBarcode (string barcode)
        {
             TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiResponse<ProductInformationDto> localVarResponse = GetByBarcodeWithHttpInfo(barcode);
             return localVarResponse.Data;
        }

        /// <summary>
        ///  Gets a product by barcode
        /// </summary>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>ApiResponse of ProductInformationDto</returns>
        public TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiResponse< ProductInformationDto > GetByBarcodeWithHttpInfo (string barcode)
        {
            // verify the required parameter 'barcode' is set
            if (barcode == null)
                throw new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException(400, "Missing required parameter 'barcode' when calling ProductApi->GetByBarcode");

            TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.RequestOptions localVarRequestOptions = new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };

            var localVarContentType = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null) localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);

            var localVarAccept = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null) localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);

            if (barcode != null)
            {
                localVarRequestOptions.QueryParameters.Add(TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ClientUtils.ParameterToMultiMap("", "barcode", barcode));
            }


            // make the HTTP request
            var localVarResponse = this.Client.Get< ProductInformationDto >("/Product", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetByBarcode", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

        /// <summary>
        ///  Gets a product by barcode
        /// </summary>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>Task of ProductInformationDto</returns>
        public async System.Threading.Tasks.Task<ProductInformationDto> GetByBarcodeAsync (string barcode)
        {
             TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiResponse<ProductInformationDto> localVarResponse = await GetByBarcodeAsyncWithHttpInfo(barcode);
             return localVarResponse.Data;

        }

        /// <summary>
        ///  Gets a product by barcode
        /// </summary>
        /// <exception cref="TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="barcode"></param>
        /// <returns>Task of ApiResponse (ProductInformationDto)</returns>
        public async System.Threading.Tasks.Task<TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiResponse<ProductInformationDto>> GetByBarcodeAsyncWithHttpInfo (string barcode)
        {
            // verify the required parameter 'barcode' is set
            if (barcode == null)
                throw new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ApiException(400, "Missing required parameter 'barcode' when calling ProductApi->GetByBarcode");


            TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.RequestOptions localVarRequestOptions = new TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.RequestOptions();

            String[] _contentTypes = new String[] {
            };

            // to determine the Accept header
            String[] _accepts = new String[] {
                "application/json"
            };
            
            foreach (var _contentType in _contentTypes)
                localVarRequestOptions.HeaderParameters.Add("Content-Type", _contentType);
            
            foreach (var _accept in _accepts)
                localVarRequestOptions.HeaderParameters.Add("Accept", _accept);
            
            if (barcode != null)
            {
                localVarRequestOptions.QueryParameters.Add(TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.ClientUtils.ParameterToMultiMap("", "barcode", barcode));
            }


            // make the HTTP request

            var localVarResponse = await this.AsynchronousClient.GetAsync<ProductInformationDto>("/Product", localVarRequestOptions, this.Configuration);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetByBarcode", localVarResponse);
                if (_exception != null) throw _exception;
            }

            return localVarResponse;
        }

    }
}
