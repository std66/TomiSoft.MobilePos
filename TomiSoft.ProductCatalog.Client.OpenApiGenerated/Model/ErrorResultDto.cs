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
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = TomiSoft.ProductCatalog.Client.OpenApiGenerated.Client.OpenAPIDateConverter;

namespace TomiSoft.ProductCatalog.Client.OpenApiGenerated.Model
{
    /// <summary>
    /// ErrorResultDto
    /// </summary>
    [DataContract]
    public partial class ErrorResultDto :  IEquatable<ErrorResultDto>, IValidatableObject
    {
        /// <summary>
        /// An error code representing the root cause of the failure
        /// </summary>
        /// <value>An error code representing the root cause of the failure</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ErrorCodeEnum
        {
            /// <summary>
            /// Enum Successful for value: Successful
            /// </summary>
            [EnumMember(Value = "Successful")]
            Successful = 1,

            /// <summary>
            /// Enum GenericError for value: GenericError
            /// </summary>
            [EnumMember(Value = "GenericError")]
            GenericError = 2,

            /// <summary>
            /// Enum UnauthorizedAccess for value: UnauthorizedAccess
            /// </summary>
            [EnumMember(Value = "UnauthorizedAccess")]
            UnauthorizedAccess = 3,

            /// <summary>
            /// Enum ProductNotFound for value: ProductNotFound
            /// </summary>
            [EnumMember(Value = "ProductNotFound")]
            ProductNotFound = 4

        }

        /// <summary>
        /// An error code representing the root cause of the failure
        /// </summary>
        /// <value>An error code representing the root cause of the failure</value>
        [DataMember(Name="errorCode", EmitDefaultValue=false)]
        public ErrorCodeEnum? ErrorCode { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResultDto" /> class.
        /// </summary>
        /// <param name="errorCode">An error code representing the root cause of the failure.</param>
        /// <param name="message">A human-friendly error message in English.</param>
        public ErrorResultDto(ErrorCodeEnum? errorCode = default(ErrorCodeEnum?), string message = default(string))
        {
            this.ErrorCode = errorCode;
            this.Message = message;
        }
        
        /// <summary>
        /// A human-friendly error message in English
        /// </summary>
        /// <value>A human-friendly error message in English</value>
        [DataMember(Name="message", EmitDefaultValue=false)]
        public string Message { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ErrorResultDto {\n");
            sb.Append("  ErrorCode: ").Append(ErrorCode).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as ErrorResultDto);
        }

        /// <summary>
        /// Returns true if ErrorResultDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ErrorResultDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ErrorResultDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ErrorCode == input.ErrorCode ||
                    this.ErrorCode.Equals(input.ErrorCode)
                ) && 
                (
                    this.Message == input.Message ||
                    (this.Message != null &&
                    this.Message.Equals(input.Message))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                hashCode = hashCode * 59 + this.ErrorCode.GetHashCode();
                if (this.Message != null)
                    hashCode = hashCode * 59 + this.Message.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
